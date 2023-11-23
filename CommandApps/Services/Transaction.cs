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
    public class Transaction : ITransaction
    {
        public Transaction()
        {
            
        }
        public async Task<ServiceResponse<bool>> AddNewEmployee(EmployeeDto employee)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                //Get Existing
                List<Employee> existingEmployee = Employees.DataEmployee;

                //Check If Any Duplicate Employee
                var checkedDuplicate = existingEmployee.FirstOrDefault(x => x.FullName.ToLower().Contains(employee.FullName.ToLower()) || x.FullName.ToLower() == employee.FullName.ToLower());
                if (checkedDuplicate != null)
                {
                    response.AddException(400, "There are duplicate employee");
                    response.Result = false;
                    return response;
                }

                //Add new employee data
                var newEmployee = new Employee
                {
                    EmployeeId = EmployeeIdPrefix(existingEmployee),
                    FullName = employee.FullName,
                    BirthDate = employee.BirthDate,
                };

                Employees.AddEmployee(newEmployee);

                response.Result = true;

                return response;
            }
            catch (Exception ex)
            {
                response.AddException(501, ex.Message);
                response.Result = false;
                return response;
            }
        }

        private string EmployeeIdPrefix(List<Employee> existingEmployee)
        {
            //Find latest employeeId
            var prefix = existingEmployee.LastOrDefault();

            //new sequence employeeId
            var sequenceEmployeeId = int.Parse(prefix.EmployeeId) + 1;

            //return the result
            return sequenceEmployeeId.ToString();
        }

        public async Task<ServiceResponse<bool>> DeleteEmployee(string employeeId)
        {
            var response = new ServiceResponse<bool>();

            try
            {
                //Find the data is Exist or Not by EmployeeId
                var existingEmployee = Employees.DataEmployee.FirstOrDefault(x => x.EmployeeId == employeeId);

                //If not found will be throw an error
                if (existingEmployee is null)
                {
                    response.AddException(400, "Employee not Found");
                    response.Result = false;
                    return response;
                }

                Employees.DataEmployee.Remove(existingEmployee);

                response.Result = true;

                return response;
            }
            catch (Exception ex)
            {
                response.AddException(501, ex.Message);
                response.Result = false;
                return response;
            }
            
        }

        public IEnumerable<Employee> GetList()
        {
            //get list all employee
            var result = Employees.DataEmployee;
            return result;
        }
    }
}
