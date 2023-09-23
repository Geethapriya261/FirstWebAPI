using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata.Ecma335;

namespace FirstWebAPI.Models

{
    public class RepositoryEmployee
    {
        private NorthwindContext _context;

        public RepositoryEmployee(NorthwindContext context)

        {

            _context = context;

        }
        public List<Employee> GetEmployees()

        {

            return _context.Employees.ToList();

        }

        public int AddEmployee(Employee emp)
        {
            //_context.Employees.Add(emp);

            //_context.SaveChanges();

            //return emp;


            Employee? foundEmp = _context.Employees.Find(emp.EmployeeId);
            if (foundEmp != null)
            {
                throw new Exception("Failed to add Employess.Duplicate Id");
            }
            EntityState es = _context.Entry(emp).State;
            Console.WriteLine($"EntityState B4Add:{es.GetDisplayName()}");
            _context.Employees.Add(emp);
            es = _context.Entry(emp).State;
            Console.WriteLine($"EntityState AfterAdd:{es.GetDisplayName()}");
            int result = _context.SaveChanges();
            es = _context.Entry(emp).State;
            Console.WriteLine($"EntityState After SaveChanges:{es.GetDisplayName()}");
            return result;
        }




        public int UpdateEmployee(Employee modifiedEmployee)
        {
            EntityState es = _context.Entry(modifiedEmployee).State;
            Console.WriteLine($"EntityState before Add:{es.GetDisplayName()}");
            _context.Employees.Update(modifiedEmployee);
            es = _context.Entry(modifiedEmployee).State;
            Console.WriteLine($"EntityState after Update:{es.GetDisplayName()}");
            int result = _context.SaveChanges();
            es = _context.Entry(modifiedEmployee).State;
            Console.WriteLine($"EntityState after SaveChanges:{es.GetDisplayName()}");
            return result;
        }

        public int DeleteEmployee(int id)
        {
            Employee empToDelete = _context.Employees.Find(id);
            EntityState es = EntityState.Detached;
            int result = 0;
            if (empToDelete != null)
            {
                es = _context.Entry(empToDelete).State;
                Console.WriteLine($"EntityState before Update:{es.GetDisplayName()}");
                _context.Employees.Update(empToDelete);
                es = _context.Entry(empToDelete).State;
                Console.WriteLine($"EntityState after Update:{es.GetDisplayName()}");
                int reslt = _context.SaveChanges();
                es = _context.Entry(empToDelete).State;
                Console.WriteLine($"EntityState after SaveChanges:{es.GetDisplayName()}");
                return result;
            }
            return 0;
        }
            public Employee FindEmployeeById(int id)

            {

                Employee employee = _context.Employees.Find(id);

                return employee;

            }

          

        public int DeleteEmployee1(int id)
        {
            Employee empdelete = _context.Employees.Find(id);
            EntityState es = EntityState.Detached;
            int result = 0;
            if (empdelete != null)
            {
                es = _context.Entry(empdelete).State;
                Console.WriteLine($"EntityState before Delete:{es.GetDisplayName()}");
                _context.Employees.Remove(empdelete);//dbcontext.entity."add" used to attach
                es = _context.Entry(empdelete).State;
                Console.WriteLine($"EntityState After Delete:{es.GetDisplayName()}");
                result = _context.SaveChanges();
                es = _context.Entry(empdelete).State;
                Console.WriteLine($"EntityState After Save changes:{es.GetDisplayName()}");
            }
            return result;
        }

    }
}







