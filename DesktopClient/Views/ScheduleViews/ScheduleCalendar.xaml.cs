﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Core;
using DesktopClient.Services;
using DayColumn = DesktopClient.Views.TemplateScheduleViews.DayColumn;

namespace DesktopClient.Views.ScheduleViews
{
    /// <summary>
    /// Interaction logic for ScheduleCalendar.xaml
    /// </summary>
    public partial class ScheduleCalendar : UserControl
    {
        public static readonly TimeSpan STARTTIME = new TimeSpan(6, 0, 0);
        public static readonly TimeSpan ENDTIME = new TimeSpan(20, 0, 0);
        public static readonly double DEFAULTSHIFTLENGTH = 3;
        public static readonly int INCREMENT = 30;
        public List<DayColumn> DayColumnList { get; set; }
        public List<ScheduleShift> Shifts { get; set; }
        public List<ScheduleShift> DeletedShifts { get; set; }
        public static int WeekNumber { get; set; }
        public Schedule Schedule { get; set; }
        public int DepartmentId { get; set; }
        public DateTime SelectedWeekStartDate { get; set; }
        public List<DateBox> DateBoxes { get; set; }
        public TextBlock TxtNoSchedule { get; set; }

        public ScheduleCalendar()
        {
            InitializeComponent();
            Shifts = new List<ScheduleShift>();
            DeletedShifts = new List<ScheduleShift>();
            DayColumnList = new List<DayColumn>();
            DateBoxes = new List<DateBox>();
            TxtNoSchedule = new TextBlock();
            WeekNumber = 1;
            BtnNextWeek.IsEnabled = false;
            BtnPrevWeek.IsEnabled = false;
            BuildTimesGrid();
            BuildDayColumns();
            BuildDateBoxes();
            BtnNextWeek.IsEnabled = true;
            BtnPrevWeek.IsEnabled = true;
            SetSelectedStartDate(DateTime.Now);
            LoadShiftsIntoCalendar();
            SetShiftDropHandler();
            SetCloseShiftClicked();
            SetEmployeeDroppedHandler();
        }

        private delegate void OnNextBtnClickedHandler();
        private OnNextBtnClickedHandler _delNextBtn;

        private delegate void OnPrevBtnClickedHandler();
        private OnPrevBtnClickedHandler _delPrevBtn;

        public void SetUpAsViedEditCalendar()
        {
            SetOnDepartmentSelected();
            SetOnEditScheduleClicked();
            SetOnResetButtonClicked();

            _delNextBtn += new OnNextBtnClickedHandler(NextBtnClickedAsViewEditCalendar);
            _delPrevBtn += new OnPrevBtnClickedHandler(PreviousBtnClickedAsViewEditCalendar);
        }

        public void SetUpAsCreateCalendar()
        {
            SetOnCreateScheduleDepartmentChanged();
            SetOnGenerateScheduleButtonClicked();
            SetOnCreateScheduleClicked();

            _delNextBtn += new OnNextBtnClickedHandler(NextBtnClickedAsCreateCalendar);
            _delPrevBtn += new OnPrevBtnClickedHandler(PreviousBtnClickedAsCreateCalendar);
        }

        public void LoadShiftsIntoCalendar()
        {
            foreach (var shift in Shifts)
            {
                ScheduleShift s = (ScheduleShift)shift;
                foreach (var dbox in DateBoxes)
                {
                    if (dbox.Date.Day == s.StartTime.Day && dbox.Date.Month == s.StartTime.Month)
                    {
                        DayColumn dayCol = GetDayCoulmByName(s.StartTime.DayOfWeek.ToString());
                        dayCol.Shifts.Add(shift);
                    }
                }
            }
           DayColumnList.ForEach(x => x.RenderShifts());
        }

        private bool IsConflictingWithExistingShift(ScheduleShift scheduleShift)
        {
            bool res = false;
            foreach (Shift s in Shifts)
            {
                ScheduleShift currShift = (ScheduleShift)s;
                if (scheduleShift.Employee != currShift.Employee)
                {
                    if (scheduleShift.StartTime < currShift.StartTime &&
                        (scheduleShift.StartTime.AddHours(scheduleShift.Hours) > currShift.StartTime))
                    {
                        res = true;
                    }
                    else if (scheduleShift.StartTime > currShift.StartTime &&
                        (currShift.StartTime.AddHours(currShift.Hours) > scheduleShift.StartTime))
                    {
                        res = true;
                    }
                    else if (scheduleShift.StartTime == currShift.StartTime)
                    {
                        res = true;
                    }
                }
            }
            return res;
        }

        public DayColumn GetDayCoulmByName(string name)
        {
            return DayColumnList.Find(x => x.Name == name);
        }

        public void Disable()
        {
            GreyOut.Background = new SolidColorBrush(Colors.LightGray);
            ClearDateBoxes();
            NavCalendar.IsEnabled = false;
            IsEnabled = false;
        }
        public void Enable()
        {
            GreyOut.Background = null;
            NavCalendar.IsEnabled = true;
            IsEnabled = true;
        }

        public void BuildTimesGrid()
        {
            TimeSpan timeCount = STARTTIME;
            int rowCount = 0;
            while (timeCount <= ENDTIME)
            {
                TimesColumn.RowDefinitions.Add(new RowDefinition());
                Border border = new Border() { BorderBrush = new SolidColorBrush(Colors.Black), BorderThickness = new Thickness(0.5, 0.5, 0.5, 0.5) };
                border.Background = new SolidColorBrush(Colors.White);
                TextBlock textBlock = new TextBlock() { Text = timeCount.ToString().Substring(0, 5), FontSize = 12, FontWeight = FontWeights.Bold };
                textBlock.Margin = new Thickness(0, -2, 5, 0);
                border.Child = textBlock;
                textBlock.HorizontalAlignment = HorizontalAlignment.Right;

                TimesColumn.Children.Add(border);
                Grid.SetRow(border, rowCount);

                rowCount++;
                timeCount = timeCount.Add(new TimeSpan(0, 60, 0));
            }
        }

        public void BuildDayColumns()
        {
            int row = 3; int col = 1;
            int day = 1;
            while (day < 6)
            {
                string name = Enum.GetName(typeof(DayOfWeek), day);
                DayColumn dayCol = new DayColumn((DayOfWeek)day) { Name = name };
                CalendarGrid.Children.Add(dayCol);

                Grid.SetColumn(dayCol, col);
                Grid.SetRow(dayCol, row);
                Grid.SetRowSpan(dayCol, 12);

                day++;
                col++;

                DayColumnList.Add(dayCol);
            }
        }

        public void ClearDateBoxes()
        {
            DateBoxes.ForEach(x => x.TxtBox.Text = "");
        }

        public void BuildDateBoxes()
        {
            DateTime currentDate = DateTime.Now;
            DateTime date = (currentDate.DayOfWeek == DayOfWeek.Sunday) ? (currentDate.AddDays(-6)) : (currentDate.AddDays(-((int)currentDate.DayOfWeek - 1)));

            int row = 2; int col = 1;
            int day = 0;
            while (day < 5)
            {
                DateBox dBox = new DateBox(date.AddDays(day));
                CalendarGrid.Children.Add(dBox);

                Grid.SetColumn(dBox, col);
                Grid.SetRow(dBox, row);

                day++;
                col++;
                DateBoxes.Add(dBox);
            }
        }

        public void UpdateDateBoxes()
        {
            for (int i = 0; i < 5; i++)
            {
                DateBox curr = DateBoxes[i];
                curr.UpdateDate(SelectedWeekStartDate.AddDays(i));
            }
        }

        private void NavCalendar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavCalendar.DataContext = SelectFullWeek();
        }

        private void NavCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            SetSelectedStartDate((DateTime)NavCalendar.SelectedDate);
            NavCalendar.SelectedDate = SelectedWeekStartDate;
            UpdateDateBoxes();
            Clear();
            LoadShiftsIntoCalendar();
        }

        public void SetSelectedStartDate(DateTime date)
        {
            SelectedWeekStartDate = (date.DayOfWeek == DayOfWeek.Sunday) ? (date.AddDays(-6)) : (date.AddDays(-(int)date.DayOfWeek + 1));
        }

        private List<DateTime> SelectFullWeek()
        {
            List<DateTime> res = new List<DateTime>();
            for (int i = 0; i < 5; i++)
            {
                res.Add(new DateTime(SelectedWeekStartDate.Year, SelectedWeekStartDate.Month, SelectedWeekStartDate.Day + i));
            }
            return res;
        }

        public void SetShiftDropHandler()
        {
            Mediator.GetInstance().ShiftDropped += (s, e) =>
            {
                Clear();
                if (!e.IsLastElement && IsVisible)
                {
                    ScheduleShift ss = (ScheduleShift)e.Shift;
                    DateBox db = DateBoxes[ss.StartTime.Day - 1];
                    DateTime dt = new DateTime(db.Date.Year, db.Date.Month, db.Date.Day, ss.StartTime.Hour, ss.StartTime.Minute, 0);
                    ss.StartTime = dt;
                }
                LoadShiftsIntoCalendar();
            };
        }

        public void SetEmployeeDroppedHandler()
        {
            Mediator.GetInstance().EmployeeDropped += (e, tod, dow) =>
            {
                if (IsVisible)
                {
                    Clear();
                    ScheduleShift ss = new ScheduleShift();
                    DateBox db = DateBoxes[(int)dow - 1];
                    DateTime dt = new DateTime(db.Date.Year, db.Date.Month, db.Date.Day, tod.Hours, tod.Minutes, 0);
                    ss.StartTime = dt;
                    ss.Employee = e;
                    ss.Hours = DEFAULTSHIFTLENGTH;
                    Shifts.Add(ss);
                    LoadShiftsIntoCalendar();
                }
            };
        }

        public void SetCloseShiftClicked()
        {
            Mediator.GetInstance().ShiftCloseClicked += (s, e) =>
            {
                if (e.Shift.GetType() == typeof(ScheduleShift))
                {
                    Shifts.Remove((ScheduleShift)e.Shift);
                    DeletedShifts.Add((ScheduleShift)e.Shift);
                    DayColumnList.ForEach(x => x.ResetTimeCells());
                    Clear();
                    LoadShiftsIntoCalendar();
                }
            };
        }

        public void SetOnDepartmentSelected()
        {
            Mediator.GetInstance().CBoxDepartmentChanged += (department) =>
            {
                if (department != null)
                {
                    ScheduleProxy scheduleProxy = new ScheduleProxy();
                    try
                    {
                        Clear();
                        Schedule = scheduleProxy.GetScheduleByDepartmentIdAndDate(department.Id, DateBoxes[0].Date);
                        Shifts = Schedule.Shifts;
                        LoadShiftsIntoCalendar();
                    }
                    catch (Exception)
                    {
                        Shifts.Clear();

                        Schedule = null;
                        Clear();
                        AddTxtNoSchedule();
                    }
                }
                DepartmentId = department.Id;
                return Schedule;
            };
        }

        public void SetOnCreateScheduleDepartmentChanged()
        {
            Mediator.GetInstance().CBoxDepartmentCreateScheduleChanged += (d) =>
            {
                Clear();
                Shifts = new List<ScheduleShift>();
                LoadShiftsIntoCalendar();
            };
        }

        private void AddTxtNoSchedule()
        {
            if (IsVisible)
            {
                Grid.SetColumn(TxtNoSchedule, 1);
                Grid.SetColumnSpan(TxtNoSchedule, 4);
                Grid.SetRow(TxtNoSchedule, 5);
                TxtNoSchedule.HorizontalAlignment = HorizontalAlignment.Center;
                TxtNoSchedule.FontWeight = FontWeights.Bold;
                TxtNoSchedule.FontSize = 18;
                TxtNoSchedule.Text = "There is no schedelue for the selected time period";
                TxtNoSchedule.Background = new SolidColorBrush(Colors.White);
                CalendarGrid.Children.Add(TxtNoSchedule);
            }
        }

        public void SetOnEditScheduleClicked()
        {
            Mediator.GetInstance().EditScheduleClicked += () =>
            {
                try
                {
                    ScheduleProxy scheduleProxy = new ScheduleProxy();
                    if (Schedule != null)
                    {
                        scheduleProxy.UpdateScheduleWithDelete(Schedule, DeletedShifts);
                        MessageBox.Show("Schedule for " + Schedule.Department.Name + " Saved sucessfully");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Something went wrong! Schedule could not be saved to database! ");
                }
            };
        }

        private void SetOnGenerateScheduleButtonClicked()
        {
            Mediator.GetInstance().GenerateScheduleButtonClicked += (s) =>
            {
                if (s != null)
                {
                    Enable();
                    SelectedWeekStartDate = s.StartDate;
                    UpdateDateBoxes();
                    Schedule = s;
                    Shifts = s.Shifts;
                    BtnPrevWeek.IsEnabled = false;
                    if (s.EndDate > SelectedWeekStartDate.AddDays(7))
                    {
                        BtnNextWeek.IsEnabled = true;
                    }
                    else
                    {
                        BtnNextWeek.IsEnabled = false;
                    }
                    NavCalendar.DisplayDateStart = Schedule.StartDate;
                    NavCalendar.DisplayDateEnd = Schedule.EndDate;
                    LoadShiftsIntoCalendar();
                }
            };
        }

        public void SetOnCreateScheduleClicked()
        {
            Mediator.GetInstance().CreateScheduleClicked += () =>
            {

                if (Schedule != null)
                {
                    try
                    {
                        ScheduleProxy scheduleProxy = new ScheduleProxy();
                        scheduleProxy.InsertScheduleToDb(Schedule);
                        MessageBox.Show("The schedule for " + Schedule.Department.Name + " StartDate: " + Schedule.StartDate.ToShortDateString() + " EndDate: " + Schedule.EndDate.ToShortDateString() + " was succesfully published");
                    }
                    catch (DataInInvalidStateException)
                    {
                        MessageBox.Show("Hurlumhej!");
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Something went wrong!");

                    }
                }
            };
        }


        private void NextWeek_Click(object sender, RoutedEventArgs e)
        {
            _delNextBtn();
            LoadShiftsIntoCalendar();
        }

        private void NextBtnClickedAsViewEditCalendar()
        {
            SelectedWeekStartDate = SelectedWeekStartDate.AddDays(7);
            UpdateDateBoxes();
            NavCalendar.SelectedDate = SelectedWeekStartDate;
            Clear();

            if (Schedule != null && Schedule.EndDate.CompareTo(DateBoxes[0].Date) < 0)
            {
                try
                {
                    Schedule = new ScheduleProxy().GetScheduleByDepartmentIdAndDate(DepartmentId, DateBoxes[0].Date);
                    Shifts = Schedule.Shifts;

                }
                catch (Exception)
                {

                    AddTxtNoSchedule();
                    Schedule = null;
                }

            }
            else if (Schedule == null)
            {
                try
                {
                    Schedule = new ScheduleProxy().GetScheduleByDepartmentIdAndDate(DepartmentId, DateBoxes[0].Date);
                    Shifts = Schedule.Shifts;
                }
                catch (Exception)
                {
                    AddTxtNoSchedule();
                    Schedule = null;
                }
            }
            Mediator.GetInstance().OnNewScheduleActive(Schedule);
        }

        private void NextBtnClickedAsCreateCalendar()
        {
            SelectedWeekStartDate = SelectedWeekStartDate.AddDays(7);
            UpdateDateBoxes();
            NavCalendar.SelectedDate = SelectedWeekStartDate;
            Clear();
            if (Schedule.EndDate <= SelectedWeekStartDate.AddDays(7))
            {
                BtnNextWeek.IsEnabled = false;
            }
            BtnPrevWeek.IsEnabled = true;
        }

        private void PreviousBtnClickedAsViewEditCalendar()
        {
            SelectedWeekStartDate = SelectedWeekStartDate.AddDays(-7);
            UpdateDateBoxes();
            NavCalendar.SelectedDate = SelectedWeekStartDate;
            Clear();
            if (Schedule != null && Schedule.StartDate.CompareTo(DateBoxes[0].Date) >= 0)
            {
                try
                {
                    Schedule = new ScheduleProxy().GetScheduleByDepartmentIdAndDate(DepartmentId, DateBoxes[0].Date);
                    Shifts = Schedule.Shifts;

                }
                catch (Exception)
                {
                    AddTxtNoSchedule();
                    Schedule = null;
                }

            }
            else if (Schedule == null)
            {
                try
                {
                    Schedule = new ScheduleProxy().GetScheduleByDepartmentIdAndDate(DepartmentId, DateBoxes[0].Date);
                    Shifts = Schedule.Shifts;
                }
                catch (Exception)
                {
                    AddTxtNoSchedule();
                    Schedule = null;
                }
            }
            Mediator.GetInstance().OnNewScheduleActive(Schedule);
        }

        private void PreviousBtnClickedAsCreateCalendar()
        {
            SelectedWeekStartDate = SelectedWeekStartDate.AddDays(-7);
            UpdateDateBoxes();
            NavCalendar.SelectedDate = SelectedWeekStartDate;
            Clear();
            if (Schedule.StartDate > SelectedWeekStartDate.AddDays(-7))
            {
                BtnPrevWeek.IsEnabled = false;
            }
            BtnNextWeek.IsEnabled = true;
        }
        private void PrevWeek_Click(object sender, RoutedEventArgs e)
        {
            _delPrevBtn();
            LoadShiftsIntoCalendar();
        }

        private void SetOnResetButtonClicked()
        {
            Mediator.GetInstance().ResetButtonClicked += () =>
            {
                try
                {
                    Schedule = new ScheduleProxy().GetScheduleByDepartmentIdAndDate(Schedule.Department.Id, DateBoxes[0].Date);
                    Clear();
                    Shifts = Schedule.Shifts;
                    LoadShiftsIntoCalendar();
                }
                catch (Exception)
                {

                    MessageBox.Show("Something went wrong! Could not reset");
                }
            };
        }

        public void Clear()
        {
            if (CalendarGrid.Children.Contains(TxtNoSchedule))
            {
                CalendarGrid.Children.Remove(TxtNoSchedule);
            }
            DayColumnList.ForEach(x => x.Clear());
        }
    }
}
