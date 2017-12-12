﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.ScheduleService;
using Core;
using System.Collections.Generic;
using DatabaseAccess.Employees;
using DatabaseAccess.Departments;
using System.Transactions;
using DatabaseAccess.Tests;

namespace Tests.Services
{
    [TestClass]
    public class ScheduleServiceTests
    {
        ScheduleServiceClient client;

        [TestInitialize]
        public void TestInitialize()
        {
            client = new ScheduleServiceClient();
        }

        [TestMethod]
        public void GetSchedulesByDepartmentIdAndDateTest()
        {
            ScheduleServiceClient client = new ScheduleServiceClient();

            Schedule schedule = client.GetScheduleByDepartmentIdAndDate(1, new DateTime(2017, 12, 15));

            Assert.IsNotNull(schedule);
            Assert.AreEqual(new DateTime(2017, 11, 01), schedule.StartDate);
            Assert.AreNotEqual(0, schedule.Shifts.Count);
            Assert.AreEqual("Kolonial", schedule.Department.Name);
        }

        [TestMethod]
        public void InsertScheduleServiceTest()
        {
            DbSetUp.SetUpDb();

            ScheduleShift shift1 = new ScheduleShift() { Employee = new EmployeeRepository().GetEmployeeByUsername("MikkelP"), Hours = 8, StartTime = new DateTime(2017, 11, 28, 8, 0, 0) };
            Schedule schedule = new Schedule() { Department = new DepartmentRepository().GetDepartmentById(4), StartDate = new DateTime(2017, 11, 27, 0, 0, 0, DateTimeKind.Utc), EndDate = new DateTime(2017, 12, 15) };
            schedule.Shifts.Add(shift1);

            client.InsertScheduleToDb(schedule);

            schedule = client.GetScheduleByDepartmentIdAndDate(4, new DateTime(2017, 11, 28, 0, 0, 0));

            Assert.IsNotNull(schedule);
            Assert.AreEqual(1, schedule.Shifts.Count);
            Assert.AreEqual("Mikkel Paulsen", schedule.Shifts[0].Employee.Name);
            Assert.AreEqual("Elektronik", schedule.Department.Name);

            DbSetUp.SetUpDb();

        }

    }
}