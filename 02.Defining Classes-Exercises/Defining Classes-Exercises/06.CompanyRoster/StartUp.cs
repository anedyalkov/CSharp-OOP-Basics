namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var lines = int.Parse(Console.ReadLine());

            var employees = new List<Employee>();

           
            Employee employee;
            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (input.Length == 6)
                {
                    employee = new Employee(input[0], double.Parse(input[1]), input[2], input[3]);
                    employee.Email = input[4];
                    employee.Age = int.Parse(input[5]);
                }
                else if (input.Length == 5)
                {
                    if (int.TryParse(input[4], out int number))
                    {
                        employee = new Employee(input[0], double.Parse(input[1]), input[2], input[3], int.Parse(input[4]));

                    }
                    else
                    {
                        employee = new Employee(input[0], double.Parse(input[1]), input[2], input[3], input[4]);
                    }
                }
                else
                {
                    employee = new Employee(input[0], double.Parse(input[1]), input[2], input[3]);
                }

                employees.Add(employee);
            }

            var topDepartment = employees
                .GroupBy(e => e.Department)
                .ToDictionary(x => x.Key, x => x.Select(e => e))
                .OrderByDescending(x => x.Value.Average(e => e.Salary))
                .FirstOrDefault();

            Console.WriteLine($"Highest Average Salary: {topDepartment.Key}");

            foreach (var emp in topDepartment.Value.OrderByDescending(e => e.Salary))
            {
                Console.WriteLine($"{emp.Name} {emp.Salary:F2} {emp.Email} {emp.Age}");
            }
        }
    }
}

