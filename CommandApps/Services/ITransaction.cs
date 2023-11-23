using CommandApps.Dto;
using CommandApps.Helper;
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
        Task<ServiceResponse<bool>> AddNewEmployee(EmployeeDto employee);
        IEnumerable<Employee> GetList();
        Task<ServiceResponse<bool>> DeleteEmployee(string employeeId);
    }
}
