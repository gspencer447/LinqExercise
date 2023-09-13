using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            Console.WriteLine(numbers.Sum());
            //TODO: Print the Average of numbers
            Console.WriteLine(numbers.Average());
            //TODO: Order numbers in ascending order and print to the console
            IEnumerable<int> sortedNumbers = numbers.OrderBy(x => x);
            foreach (int number in sortedNumbers)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("------------");
            //TODO: Order numbers in descending order and print to the console
            IEnumerable<int> descNumbers = numbers.OrderByDescending(x => x);
            foreach (int number in descNumbers)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("------------");
            //TODO: Print to the console only the numbers greater than 6
            IEnumerable<int> greaterNumbers = numbers.Where(x => x > 6);
            foreach (int number in greaterNumbers)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("------------");
            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
            IEnumerable<int> fourNumbers = numbers.OrderBy(x => x).Take(4);
            foreach (int number in fourNumbers)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("------------");
            //TODO: Change the value at index 4 to your age, then print the numbers in descending order
            numbers[4] = 29;
            var ageDescending = numbers.OrderByDescending(x => x);
            foreach (int number in ageDescending)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("------------");
            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            Employee employee1 = new Employee()
            {
                FirstName = "Graham",
                LastName = "Spencer",
                Age = 29,
                YearsOfExperience = 1,
            };
            Employee employee2 = new Employee()
            {
                FirstName = "Taylor",
                LastName = "McGregor",
                Age = 31,
                YearsOfExperience = 5,
            };
            Employee employee3 = new Employee()
            {
                FirstName = "Gabe",
                LastName = "Bealer",
                Age = 28,
                YearsOfExperience = 0,
            };
            Employee employee4 = new Employee()
            {
                FirstName = "Frank",
                LastName = "Alves",
                Age = 22,
                YearsOfExperience = 0,
            };

            var employeesFiltered = employees
            .Where(e => e.FirstName.StartsWith("C") ||
            e.FirstName.StartsWith("S"))
            .OrderBy(e => e.FirstName);
            foreach (Employee employee in employeesFiltered)
            {
                Console.WriteLine(employee.FullName);
            }
            Console.WriteLine("-------------");


            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            var ageAndFirstName = employees
            .Where(e => e.Age > 26).OrderBy(e => e.Age).ThenBy(e => e.FirstName);
            foreach (Employee employee in ageAndFirstName)
            {
                Console.WriteLine(employee.FullName + " " + employee.Age);
            }
            Console.WriteLine("-------------");
            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var sum = employees.Where(e => e.YearsOfExperience <= 10 && e.Age > 35).Sum(e => e.YearsOfExperience);
            var average = employees.Where(e => e.YearsOfExperience <= 10 && e.Age > 35).Average(e => e.YearsOfExperience);
            Console.WriteLine(sum);
            Console.WriteLine(average);
            Console.WriteLine("-------------");
            //TODO: Add an employee to the end of the list without using employees.Add()
            employees.Append(employee1).ToList().ForEach (x => Console.WriteLine(x.FullName));

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
