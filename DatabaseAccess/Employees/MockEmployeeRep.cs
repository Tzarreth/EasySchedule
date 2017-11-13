﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace DatabaseAccess.Employees
{
    public class MockEmployeeRep : IEmployeeRepository
    {

        public List<Employee> GetAllEmployees()
        {
            List<Employee> res = new List<Employee>();

            Employee e1 = new Employee();
            Employee e2 = new Employee();
            Employee e3 = new Employee() { Name = "Hanne" };

            res.Add(e1);
            res.Add(e2);
            res.Add(e3);

            return res;
        }

    }
}
