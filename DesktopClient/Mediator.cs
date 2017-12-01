﻿using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DesktopClient
{
    public class Mediator
    {
        private static Mediator _instance;

        private Mediator()
        {

        }

        public static Mediator GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Mediator();
            }

            return _instance;
        }

        public event EventHandler<ShiftDropEventArgs> ShiftDropped;

        public void OnShiftDropped(object sender, Shift shift, bool isLastElement)
        {
            var shiftDroppedDelegate = ShiftDropped as EventHandler<ShiftDropEventArgs>;
            if (shiftDroppedDelegate != null)
            {
                shiftDroppedDelegate(sender, new ShiftDropEventArgs { Shift = shift, IsLastElement = isLastElement });
            }
        }

        public event EventHandler<ShiftDropEventArgs> ShiftCloseClicked;
        public void OnShiftCloseClick(object sender, Shift shift)
        {
            var shiftCloseDelegate = ShiftCloseClicked as EventHandler<ShiftDropEventArgs>;
            if (shiftCloseDelegate != null)
            {
                shiftCloseDelegate(sender, new ShiftDropEventArgs { Shift = shift });
            }
        }

        public delegate void EmployeeDroppedHandler(Employee employee, TimeSpan timeOfDay, DayOfWeek dayOfWeek);
        public event EmployeeDroppedHandler EmployeeDropped;
        public void OnEmployeeDropped(Employee employee, TimeSpan timeOfDay, DayOfWeek dayOfWeek)
        {
            if (EmployeeDropped != null)
            {
                EmployeeDropped(employee, timeOfDay, dayOfWeek);
            }
        }

        public event EventHandler<TemplateSelectedArgs> TemplateScheduleSelected;
        public void OnTemplateScheduleSelected(object sender, TemplateSchedule templateSchedule)
        {
            var templateScheduleSelected = TemplateScheduleSelected as EventHandler<TemplateSelectedArgs>;
            if (templateScheduleSelected != null)
            {
                templateScheduleSelected(sender, new TemplateSelectedArgs { TemplateSchedule = templateSchedule });
            }
        }

        public event EventHandler<TemplateSelectedArgs> TemplateScheduleUpdateClicked;
        public void OnTemplateScheduleUpdateButtonClicked(object sender, TemplateSchedule templateSchedule)
        {
            var templateScheduleUpdateClicked = TemplateScheduleUpdateClicked as EventHandler<TemplateSelectedArgs>;
            if (templateScheduleUpdateClicked != null)
            {
                templateScheduleUpdateClicked(sender, new TemplateSelectedArgs { TemplateSchedule = templateSchedule });
            }
        }

        public delegate void DepartmentBoxChangedHandler(List<Employee> employees, Department department);

        public delegate void EditScheduleClickedHandler();
        public event EditScheduleClickedHandler EditScheduleClicked;
        public void OnEditScheduleClicked()
        {
            if (EditScheduleClicked != null)
            {
                EditScheduleClicked();
            }
        }

        public delegate void GenerateScheduleButtonClickedHandler(Schedule schedule);
        public event GenerateScheduleButtonClickedHandler GenerateScheduleButtonClicked;

        public delegate void CreateScheduleClickedHandler();
        public event CreateScheduleClickedHandler CreateScheduleClicked;
        public void OnCreateScheduleButtonClicked()
        {
            if (CreateScheduleClicked != null)
            {
                CreateScheduleClicked();
            }
        }

        public void OnGenerateScheduleButtonClicked(Schedule schedule)
        {
            if (GenerateScheduleButtonClicked != null)
            {
                GenerateScheduleButtonClicked(schedule);
            }
        }

        public event DepartmentBoxChangedHandler DepartmentBoxChanged;

        public void OnDepartmentBoxSelected(List<Employee> employees, Department department)
        {
            if (DepartmentBoxChanged != null)
            {
                DepartmentBoxChanged(employees, department);
            }
        }

        public delegate void CBoxDepartmentChangedHandler(Department department, Schedule schedule);
        public event CBoxDepartmentChangedHandler CBoxDepartmentChanged;
        public void OnCBoxSelectionChanged(Department department, Schedule schedule)
        {
            if (DepartmentBoxChanged != null)
            {
                CBoxDepartmentChanged(department, schedule);
            }
        }

        public delegate void CreateTemplateScheduleButtonClickedHandler(TemplateSchedule templateSchedule);
        public event CreateTemplateScheduleButtonClickedHandler CreateTemplateScheduleButtonClicked;

        public void OnCreateTemplateScheduleButtonClicked(TemplateSchedule templateSchedule)
        {
            if (CreateTemplateScheduleButtonClicked != null)
            {
                CreateTemplateScheduleButtonClicked(templateSchedule);
            }
        }

        public delegate void MenuItemChangedHandler();
        public event MenuItemChangedHandler MenuItemChanged;
        public void OnMenuItemChanged()
        {
            if (MenuItemChanged != null)
            {
                MenuItemChanged();
            }
        }

        public delegate void CreateEmployeeClickedHandler();
        public event CreateEmployeeClickedHandler CreateEmployeeClicked;
        internal void OnCreateEmployeeClicked()
        {
            if (CreateEmployeeClicked != null)
            {
                CreateEmployeeClicked();
            }
        }

        public delegate void UpdateEmployeeClickedHandler();
        public event UpdateEmployeeClickedHandler UpdateEmployeeClicked;
        internal void OnUpdateEmployeeClicked()
        {
            if (UpdateEmployeeClicked != null)
            {
                UpdateEmployeeClicked();
            }
        }

        public delegate void NumOfWeekBoxChangedHandler(int numOfWeeks, ComboBox numOfWeeksBox, int prevSelection);
        public event NumOfWeekBoxChangedHandler NumOfWeekBoxChanged;
        public void OnNumOfWeekBoxChanged(int numOfWeeks, ComboBox numOfWeeksBox, int prevSelection)
        {
            if (NumOfWeekBoxChanged != null)
            {
                NumOfWeekBoxChanged(numOfWeeks, numOfWeeksBox, prevSelection);
            }
        }

        public delegate void NextOrPrevClickedHandler(Schedule schedule);
        public event NextOrPrevClickedHandler NextOrPrevClicked;
        public void OnNextOrPreviousButtonClicked(Schedule schedule)
        {
            if (NextOrPrevClicked != null)
            {
                NextOrPrevClicked(schedule);
            }
        }
    }
}
