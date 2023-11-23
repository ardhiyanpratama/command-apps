using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandApps.Models
{
    public class Employee
    {

        public string? EmployeeId { get; set; }
        public string? FullName { get; set; }
        public DateTime BirthDate { get; set; }
    }
    public static class Employees
    {
        public static List<Employee> DataEmployee { get;} = new List<Employee>
        {
            new Employee
            {
                EmployeeId = "1001",
                FullName = "Adit",
                BirthDate = new DateTime(1954, 8, 17)
            }, new Employee
            {
                EmployeeId = "1002",
                FullName = "Anton",
                BirthDate = new DateTime(1954, 8, 18)
            }, new Employee
            {
                EmployeeId = "1003",
                FullName = "Amir",
                BirthDate = new DateTime(1954, 8, 19)
            }
        };

        public static void AddEmployee(Employee employee)
        {
            DataEmployee.Add(employee);
        }
    }
}
