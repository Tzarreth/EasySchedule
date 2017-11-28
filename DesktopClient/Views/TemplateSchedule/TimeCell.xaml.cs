﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Core;

namespace DesktopClient
{
    /// <summary>
    /// Interaction logic for TimeCell.xaml
    /// </summary>
    public partial class TimeCell : UserControl
    {
        public List<TemplateShift> ShiftsInCell { get; set; }
        public TemplateSchedule TemplateSchedule { get; set; }
        public TimeSpan Time { get; set; }
        public DayOfWeek weekDay { get; set; }
        public TimeCell()
        {
            InitializeComponent();
            ShiftsInCell = new List<TemplateShift>();
            SetDropHandler();
            SetCloseClick();
            SetEmployeeDropped();
            SetTemplateScheduleSelected();
            SetOnTemplateScheduleUpdateClicked();
            SetOnMenuItemChanged();
        }

        public Grid GetGrid()
        {
            return TimeCellGrid;
        }

        public void SetToolTipText(string text)
        {
            TimeCellGrid.ToolTip = text;
        }


        public void FillCell(TemplateShift shift, bool isFirstElement, bool isLastElement)
        {
            Color color = TemplateScheduleCalendarView.EmployeeColors[shift.Employee.Name];
            
            ShiftElement shiftElement = null;
            if (isFirstElement)
            {
                shiftElement = new ShiftElement(shift, shift.Employee.Name, color);
                
               // Border.BorderThickness = new Thickness(0.1, 0.1, 0.1, 0);
             
            }
            else if (isLastElement)
            {
                shiftElement = new ShiftElement(shift, color, true);
                //Border.BorderThickness = new Thickness(0.1, 0, 0.1, 0.1);
            }
            else // Middle Element 
            {
                shiftElement = new ShiftElement(shift, color, false);
               // Border.BorderThickness = new Thickness(0.1, 0, 0.1, 0);
            }

            TimeCellGrid.ColumnDefinitions.Add(new ColumnDefinition());

            TimeCellGrid.Children.Add(shiftElement);
            Grid.SetColumn(shiftElement, ShiftsInCell.Count);

            ShiftsInCell.Add(shift);

        }

        private void OnHandleDrop(object sender, DragEventArgs e)
        {
            object droppedItem = e.Data.GetData("Object");

            if (droppedItem.GetType() == typeof(TemplateShift))
            {
                TemplateShift droppedShift = (TemplateShift)e.Data.GetData("Object");
                bool isLastElement = (bool)e.Data.GetData("IsLastShiftElement");
                if (isLastElement)
                {
                    TimeCellGrid.Background = new SolidColorBrush(Colors.White);
                    droppedShift.Hours = (Time.Subtract(droppedShift.StartTime).Add(new TimeSpan(0, TemplateScheduleCalendar.INCREMENT, 0)).TotalHours);
                }
                else
                {
                    droppedShift.StartTime = Time;
                    droppedShift.WeekDay = weekDay;
                }

                Mediator.GetInstance().OnShiftDropped(sender, droppedShift, isLastElement);
            }

            else if (droppedItem.GetType() == typeof(Employee))
            {
                Employee employee = (Employee)droppedItem;
                TemplateShift newShift = new TemplateShift() { StartTime = Time, WeekDay = weekDay, Employee = employee, Hours = 3 }; // DEFAULT HOURS = 3
                if (TemplateSchedule != null)
                {
                    newShift.TemplateScheduleID = TemplateSchedule.ID;
                }
                Mediator.GetInstance().OnEmployeeDropped(sender, newShift);
            }




        }

        private void SetDropHandler()
        {
            Mediator.GetInstance().ShiftDropped += (s, e) =>
            {
                Clear();
            };
        }

        private void SetCloseClick()
        {
            Mediator.GetInstance().ShiftCloseClicked += (s, e) =>
            {
                Clear();
            };
        }

        private void SetEmployeeDropped()
        {
            Mediator.GetInstance().EmployeeDropped += (s, e) =>
            {
                Clear();
            };
        }

        private void SetTemplateScheduleSelected()
        {
            Mediator.GetInstance().TempScheduleSelected += (s, e) =>
            {
                TemplateSchedule = e.TempSchedule;
                Clear();
            };
        }

        private void SetOnTemplateScheduleUpdateClicked()
        {
            Mediator.GetInstance().TempScheduleUpdateClicked += (s, e) =>
            {
                Clear();
            };
        }

        private void SetOnMenuItemChanged()
        {
            Mediator.GetInstance().MenuItemChanged += () =>
            {
                Clear();
            };
        }


        public void Clear()
        {
            TemplateSchedule = null;
            ShiftsInCell = new List<TemplateShift>();
            TimeCellGrid.Children.Clear();
            TimeCellGrid.ColumnDefinitions.Clear();
           // Border.BorderThickness = new Thickness(0.1, 0.1, 0.1, 0.1);
        }

        private void Border_DragEnter(object sender, DragEventArgs e)
        {
            Background = new SolidColorBrush(Colors.LightGray);
        }

        private void Border_DragLeave(object sender, DragEventArgs e)
        {
            Background = null;
        }

   
    }
}