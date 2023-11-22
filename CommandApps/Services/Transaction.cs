using CommandApps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandApps.Services
{
    public class Transaction : ITransaction
    {
        public Transaction()
        {
            
        }
        public void AddNewEmployee(Employee employee)
        {
            //Add new employee data
            throw new NotImplementedException();
        }

        public void DeleteEmployee(string employeeId)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Employee> GetList()
        {
            var result = Employees.GetEmployee();
            throw new NotImplementedException();
        }
    }
}
