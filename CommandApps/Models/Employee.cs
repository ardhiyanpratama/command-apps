using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandApps.Models
{
    public class Employee
    {
        public string? EmployeeId { get; set; }
        public string? FullName { get; set; }
        public DateOnly BirthDate { get; set; }
    }
    public static class Employees
    {
        public static IEnumerable<Employee> GetEmployee()
        {
            yield return new Employee
            {
                EmployeeId = "1001",
                FullName = "Adit",
                BirthDate = new DateOnly(1954, 8, 17)
            };
            yield return new Employee
            {
                EmployeeId = "1002",
                FullName = "Anton",
                BirthDate = new DateOnly(1954, 8, 18)
            };
            yield return new Employee
            {
                EmployeeId = "1003",
                FullName = "Amir",
                BirthDate = new DateOnly(1954, 8, 19)
            };
        }
    }
}
