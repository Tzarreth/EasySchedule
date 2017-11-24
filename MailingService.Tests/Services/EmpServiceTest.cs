﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.EmployeeService;
using Core;
using System.Collections.Generic;
using Tests.DatabaseAccess;

namespace Tests.Services
{
    
    [TestClass]
    public class EmpServiceTest
    {
        EmployeeServiceClient client;


        [TestInitialize]
        public void TestInitialize()
        {
            client = new EmployeeServiceClient();
            DBSetUp.SetUpDB();
        }

   

        [TestMethod]
        public void TestEmployeeServiceGetEmployeeByUsername()
        {
        
            string expected = "Tobias Andersen";
            string actual = client.GetEmployeeByUsername("TobiAs").Name;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestEmployeeServiceInsertEmployee()
        {
            Employee emp = new Employee()
            {
                Name = "Anders Andersen",
                IsAdmin = false,
                Mail = "andersen@bøgs.dk",
                Phone = "98901349",
                NumbOfHours = 37,
                IsEmployed = true,
                Username = "AAndersen",
                DepartmentId = 3,
                Password = "GotMilk?"
            };

            client.InsertEmployee(emp);

            emp = client.GetEmployeeByUsername("AAndersen");
            List<Employee> emps = client.GetAllEmployees();

            Assert.IsNotNull(emp);
            Assert.AreEqual("Anders Andersen", emp.Name);
            Assert.AreEqual(6, emp.Id);
            Assert.AreEqual(emps.Count, 6);

        }

        [TestMethod]
        public void TestEmployeeServiceUpdateEmployee()
        {
            Employee emp = client.GetEmployeeByUsername("MikkelP");

            Assert.IsNotNull(emp);
            Assert.AreEqual("Mikkel Paulsen", emp.Name);

            emp.Name = "Mikkel Hansen";

            client.UpdateEmployee(emp);

            emp = client.GetEmployeeByUsername("MikkelP");
            Assert.IsNotNull(emp);
            Assert.AreEqual("Mikkel Hansen", emp.Name);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            DBSetUp.SetUpDB();
        }
    }
}
