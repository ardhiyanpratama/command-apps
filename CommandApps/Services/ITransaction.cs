using CommandApps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandApps.Services
{
    public interface ITransaction
    {
        void AddNewEmployee(Employee employee);
        ValueTask<Employee> GetList();
        void DeleteEmployee(string employeeId);
    }
}
