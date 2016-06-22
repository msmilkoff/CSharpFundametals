namespace _02.CompanyRoster
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CompanyRoster
    {
        public static void Main()
        {
            var departments = new Dictionary<string, List<Employee>>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                var employeeInfo = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                string name = employeeInfo[0];
                decimal salary = decimal.Parse(employeeInfo[1]);
                string position = employeeInfo[2];
                string department = employeeInfo[3];

                var employee = new Employee(name, salary, position, department);

                int age;
                if (employeeInfo.Length == 5)
                {
                    if (int.TryParse(employeeInfo[4], out age))
                    {
                        employee.Age = age;
                    }
                    else
                    {
                        employee.Email = employeeInfo[4];
                    }
                }
                else if (employeeInfo.Length == 6)
                {
                    employee.Age = int.Parse(employeeInfo[5]);
                    employee.Email = employeeInfo[4];
                }
                
                if (!departments.ContainsKey(department))
                {
                    departments.Add(department, new List<Employee>());
                }

                departments[department].Add(employee);
            }

            var bestDepartment = departments
                    .OrderByDescending(d => d.Value.Average(e => e.Salary))
                    .First();

            Console.WriteLine($"Highest Average Salary: {bestDepartment.Key}");
            Console.WriteLine(string.Join("\n", bestDepartment.Value.OrderByDescending(e => e.Salary)));
        }

        public class Employee
        {
            public Employee(
                string name,
                decimal salary,
                string position,
                string department,
                string email = "n/a",
                int age = -1)
            {
                this.Name = name;
                this.Salary = salary;
                this.Position = position;
                this.Department = department;
                this.Email = email;
                this.Age = age;
            }

            public string Name { get; set; }

            public decimal Salary { get; set; }

            public string Position { get; set; }

            public string Department { get; set; }

            public string Email { get; set; }

            public int Age { get; set; }

            public override string ToString()
            {
                string result = $"{this.Name} {this.Salary:F2} {this.Email} {this.Age}";

                return result;
            }
        }
    }
}
