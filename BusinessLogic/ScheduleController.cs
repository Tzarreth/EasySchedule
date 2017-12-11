﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using DatabaseAccess;
using DatabaseAccess.Schedules;
using DatabaseAccess.Departments;
using DatabaseAccess.ScheduleShifts;

namespace BusinessLogic
{
    public class ScheduleController : IScheduleController
    {
        private readonly IScheduleRepository _scheduleRepository;
        public IScheduleShiftRepository ScheduleShiftRepository { get; set; }

        public ScheduleController(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
            ScheduleShiftRepository = new ScheduleShiftRepository();
        }

        public Schedule GetScheduleByDepartmentIdAndDate(int departmentId, DateTime date)
        {
            Schedule schedule = null;
            List<Schedule> schedules = _scheduleRepository.GetSchedulesByDepartmentId(departmentId);
            if (schedules != null)
            {
                foreach (Schedule temporarySchedule in schedules)
                {
                    if (date.CompareTo(temporarySchedule.StartDate) > 0 && date.CompareTo(temporarySchedule.EndDate) < 0)
                    {
                        schedule = temporarySchedule;
                    }
                }
                if (schedule != null)
                {
                    schedule.Shifts = new ScheduleShiftRepository().GetShiftsByScheduleId(schedule.Id);
                }
             
            }


            return schedule;
        }

        public void InsertScheduleToDb(Schedule schedule)
        {
            if (GetScheduleByDepartmentIdAndDate(schedule.Department.Id, schedule.StartDate) == null
                        && GetScheduleByDepartmentIdAndDate(schedule.Department.Id, schedule.EndDate) == null)
            {
                _scheduleRepository.InsertSchedule(schedule);
            }
            else
            {
                throw new Exception("Insert schedule failed. Schedule time overlaps existing schedule");
            }
           
        }

        public void UpdateSchedule(Schedule schedule)
        {
            _scheduleRepository.UpdateSchedule(schedule);
        }

        public List<Schedule> GetSchedulesByDepartmentId(int departmentId)
        {
            return _scheduleRepository.GetSchedulesByDepartmentId(departmentId);
        }

        /// <summary>
        /// This method takes a templateSchedule and returns a Schedule for the user to use.
        /// The returned Schedule can after the call be used without interfering with the template, and used as a base plan for your team.
        /// </summary>
        /// <param name="templateSchedule"></param>
        /// <param name="startTime"></param>
        /// <returns>
        /// Returns a schedule object with shifts added.
        /// </returns>
        public Schedule GetShiftsFromTemplateShift(TemplateSchedule templateSchedule, DateTime startTime)
        {
            Schedule schedule = new Schedule();
            foreach (TemplateShift templateShift in templateSchedule.TemplateShifts)
            {
                ScheduleShift shift = new ScheduleShift();
                shift.Employee = templateShift.Employee;
                shift.Hours = templateShift.Hours;
                shift.StartTime = startTime.AddDays(((int)templateShift.WeekDay - 1) + (templateShift.WeekNumber - 1) * 7);
                shift.StartTime = shift.StartTime.AddHours(templateShift.StartTime.Hours);
                shift.StartTime = shift.StartTime.AddMinutes(templateShift.StartTime.Minutes);
                schedule.Shifts.Add(shift);
            }
            schedule.Department = new DepartmentRepository().GetDepartmentById(templateSchedule.DepartmentId);
            schedule.StartDate = startTime;
            schedule.EndDate = startTime.AddDays(7 * templateSchedule.NoOfWeeks);
            return schedule;
        }

        /// <summary>
        /// This method is used when a user wants to accept a shift, that is available for sale.
        /// The method will also call the MailGun api method to send a mail to the employee whom accepted a shift.
        /// </summary>
        /// <param name="shift"></param>
        /// <param name="employee"></param>
        public void AcceptAvailableShift(ScheduleShift shift, Employee employee)
        {

            if (shift.StartTime < DateTime.Now && shift.IsForSale)
            {
                ScheduleShiftRepository.AcceptAvailableShift(shift, employee);

                MailSender mailSender = new MailSender();
                string subject = "A shift has been accepted";
                string text = "The shift starting " + shift.StartTime + " and has a length of " + shift.Hours + " hours has been accepted by " + employee.Name;
                //TODO: Next line is commented out so that we won't recieve mails when testing the program
                //mailSender.SendMailToEmployeesInDepartmentByDepartmentId(subject, text, employee.DepartmentId);
            }
            else
            {
                throw new ArgumentException("Failure to accept shift. One or more arguments are illegal!");
            }
        }

        public List<ScheduleShift> GetAllAvailableShiftsByDepartmentId(int departmentId)
        {
            return ScheduleShiftRepository.GetAllAvailableShiftsByDepartmentId(departmentId);
        }

        public void SetScheduleShiftForSale(ScheduleShift scheduleShift)
        {
            ScheduleShiftRepository.SetScheduleShiftForSale(scheduleShift);
            MailSender mailSender = new MailSender();
            string subject = "A new shift has been set for sale";
            string text = scheduleShift.Employee.Name + " has set a shift starting " + scheduleShift.StartTime + " and has a length of " + scheduleShift.Hours + " hours for sale.";
            //TODO: Next line is commented out so that we won't recieve mails when testing the program
            //mailSender.SendMailToEmployeesInDepartmentByDepartmentId(subject, text, scheduleShift.Employee.DepartmentId);
        }
    }
}
