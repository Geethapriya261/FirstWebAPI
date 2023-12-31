﻿using FirstWebAPI.Models;
using Microsoft.AspNetCore.Mvc;


using FirstWebAPI.Models;

using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;

using System.Diagnostics.Contracts;

using System.Reflection.Metadata.Ecma335;

 

namespace FirstWebAPI.Controllers

{

    [Route("api/[controller]")]

    [ApiController]

    public class EmployeeController : ControllerBase

    {

        private RepositoryEmployee _context;

        public EmployeeController(RepositoryEmployee context)

        {

            _context = context;
        }

        [HttpGet("/GetAll")]

        public IEnumerable<EmpViewModel> AllEmployee()

        {

            List<Employee> employees = _context.GetEmployees();
            var emplist = (

                from emp in employees

                select new EmpViewModel()

                {

                    EmpId = emp.EmployeeId ,

                    FirstName = emp.FirstName,

                    LastName = emp.LastName,

                    Title = emp.Title,

                    BirthDate = emp.BirthDate,

                    HireDate = emp.HireDate,

                    City = emp.City,

                    ReportsTo = emp.ReportsTo

                }

                ).ToList();

            return emplist;

        }

        [HttpGet("search/employee")]

        public Employee EmployeeDetails(int id)

        {

            Employee employee = _context.FindEmployeeById(id);

            return employee;

        }

        [HttpPost("/AddNewEmployees")]

        public int AddEmployee([FromBody] Employee emp)

        {

            Employee employee = new Employee()

            {

                //EmployeeId=newEmployee.EmpId,

                FirstName = emp.FirstName,

                LastName = emp.LastName,

                Title = emp.Title,

                BirthDate = emp.BirthDate,

                HireDate = emp.HireDate,

                City = emp.City,

                ReportsTo = emp.ReportsTo > 0 ? emp.ReportsTo : null



            };

            return _context.AddEmployee(employee);

        }

        [HttpPut("/ModifyEmployee")]

        public int UpdateEmployee(int id, [FromBody] Employee emp)

        {

            emp.EmployeeId = id;

            return _context.UpdateEmployee(emp);


        }



        [HttpDelete("/DeleteEmployee")]

        public int DeleteEmployee(int id)

        {

            _context.DeleteEmployee(id);

            return id;

        }

    }

}
