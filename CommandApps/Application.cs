using CommandApps.Dto;
using CommandApps.Models;
using CommandApps.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommandApps
{
    public class Application
    {
        private readonly ITransaction _transaction;

        public Application(ITransaction transaction)
        {
            _transaction = transaction;
        }
        public void Run(string[]args)
        {
            //Configure the menu
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Command Apps");
            Console.WriteLine();
            Console.ResetColor();

            bool finished = false;
            do
            {
                //List Menu
                Console.WriteLine($"1. Add Employee\u001b[0m");
                Console.WriteLine($"2. Display Employee\u001b[0m");
                Console.WriteLine($"3. Remove/Delete Employee\u001b[0m");

                Console.Write("Choose : ");

                int option = int.Parse(Console.ReadLine());

                Console.Clear();

                //Action to redirect inside the menu
                switch (option)
                {
                    case 1:
                        AddDataMenu();
                        break;
                    case 2:
                        DisplayData();
                        break;
                    case 3:
                        RemoveData();
                        break;
                    default:
                        break;
                }

                Console.WriteLine();
                Console.Write("Back to main menu (y/N)");
                char c = char.Parse(Console.ReadLine());

                try
                {
                    if (c == 'y')
                    {
                        finished = false;
                    }
                    else
                    {
                        finished = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
                

                Console.Clear();

            } while (!finished);
        }

        private async void RemoveData()
        {
            bool finishedRemove = false;
            do
            {
                //Configure the menu
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Remove/Delete Employee");
                Console.WriteLine();
                Console.ResetColor();

                //Get List Employee
                var result = _transaction.GetList();

                //Check if there is any data employee
                if (result.Count() == 0)
                {
                    //If data 0 or none will be show information below
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There is no data to display");
                    Console.ResetColor();
                }
                else
                {
                    //Showing the data
                    foreach (var item in result)
                    {
                        Console.WriteLine($"EmployeeId : {item.EmployeeId}");
                        Console.WriteLine($"FullName : {item.FullName}");
                        Console.WriteLine($"FullName : {item.BirthDate.ToString("dd-MMM-yy")}");
                        Console.WriteLine("================================================================");
                    }

                    Console.WriteLine();
                    //Insert employeeId
                    Console.Write("Please insert the employeeId : ");
                    string employeeId = Console.ReadLine();
                    Console.Write("Are you sure want to delete this employee (y/N) ");
                    char delete = char.Parse(Console.ReadLine());

                    try
                    {
                        if (delete == 'y')
                        {
                            //Delete employee
                            var resultDeleted = await _transaction.DeleteEmployee(employeeId);

                            //Check if there any error
                            if (!resultDeleted.HasError)
                            {
                                //If not show success message and user can remove again and the list will be refresh
                                Console.WriteLine("Data employee has been succesfull remove");
                                Console.Clear();
                                finishedRemove = false;
                            }
                            else
                            {
                                //If fail show message
                                Console.Write($"Error message : {resultDeleted?.Exceptions?.FirstOrDefault()?.Message}, with code {resultDeleted?.Exceptions?.FirstOrDefault()?.Code}");
                                Console.ReadLine();
                                Console.Clear();
                            }
                        }
                        else
                        {
                            finishedRemove = true;
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.Write(ex.Message);
                    }
                    
                }
            } while (!finishedRemove);
        }

        private async void AddDataMenu()
        {
            bool finishedAddedEmployee = false;
            do
            {
                //Configure the menu
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Add New Employee");
                Console.ResetColor();

                Console.Write("\r\nFullname: ");
                string fullname = Console.ReadLine();
                Console.Write("\r\nBirthdate: ");
                string birthDate = Console.ReadLine();

                //parsing variable input to the employeeDto model
                EmployeeDto employee = new EmployeeDto
                {
                    FullName = fullname,
                    BirthDate = DateTime.Parse(birthDate)
                };

                // Validate the input
                if (employee.IsValid())
                {
                    //Insert new employee
                    var result = await _transaction.AddNewEmployee(employee);
                    //Check if there any error
                    if (!result.HasError)
                    {
                        //If not show success message and user can add new employee again
                        Console.WriteLine();
                        Console.WriteLine("Data employee has been succesfull added");
                        Console.WriteLine();
                        Console.Write("Do you want to add more employee (y/N) ");
                        char more = char.Parse(Console.ReadLine());

                        try
                        {
                            if (more == 'y')
                            {
                                finishedAddedEmployee = false;
                                Console.Clear();
                            }
                            else
                            {
                                finishedAddedEmployee = true;
                            }
                        }
                        catch (Exception ex)
                        {

                            Console.Write(ex.Message);
                        }
                       
                    }
                    else
                    {
                        //If fail show message
                        Console.WriteLine($"Error message : {result?.Exceptions?.FirstOrDefault()?.Message}, with code {result?.Exceptions?.FirstOrDefault()?.Code}");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("Model is not valid. Please fix the validation errors.");
                }
            }while (!finishedAddedEmployee);
            
        }

        private void DisplayData()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Display Employee");
            Console.WriteLine();
            Console.ResetColor();

            var result = _transaction.GetList();

            if (result.Count() == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There is no data to display");
                Console.ResetColor();
            }
            else
            {
                foreach (var item in result)
                {
                    Console.WriteLine($"EmployeeId : {item.EmployeeId}");
                    Console.WriteLine($"FullName : {item.FullName}");
                    Console.WriteLine($"FullName : {item.BirthDate.ToString("dd-MMM-yy")}");
                    Console.WriteLine("================================================================");
                }
            }
        }
    }
}
