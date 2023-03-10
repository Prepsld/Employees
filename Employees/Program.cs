using Employees.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    /// <summary>
    /// CPRG211 - Lab Inheritance
    /// </summary>
    /// <remarks>Author: Nick Hamnett, finished by David Prepsl</remarks>
    /// <remarks>Date: February 5th, 2023 </remarks>
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create list that holds Employee instances
            List<Employee> employees = new List<Employee>();

            // Must be a relative path
            string path = "employees.txt";

            // Converts lines in file into an array of strings
            string[] lines = File.ReadAllLines(path);

            // Loop through each line
            foreach (string line in lines)
            {
                // Split line into parts or cells.
                string[] cells = line.Split(':');

                // The first 3 cells are the ID, name, and address.
                string id = cells[0];
                string name = cells[1];
                string address = cells[2];

                // TODO: Get remaining employee info from cells
                string phoneNumber = cells[3];
                long sinNum = long.Parse(cells[4]);
                string birthday = cells[5];
                string department = cells[6];

                // Extract the first digit of the ID.
                string firstDigit = id.Substring(0, 1);

                // Convert first digit from string to int.
                int firstDigitInt = int.Parse(firstDigit);

                // Check range of first digit
                if (firstDigitInt >= 0 && firstDigitInt <= 4)
                {
                    // Salaried
                    string salary = cells[7];

                    // Convert salary from string to double.
                    double salaryDouble = double.Parse(salary);

                    // Create Salaried instance
                    Salaried salaried = new Salaried(id, name, address, phoneNumber, sinNum, birthday, department, salaryDouble);

                    // Add to list of employees.
                    employees.Add(salaried);
                }
                else if (firstDigitInt >= 5 && firstDigitInt <= 7)
                {
                    // Wage
                    string rate = cells[7];
                    string hours = cells[8];

                    // Convert rate and hours from string to double
                    double rateDouble = double.Parse(rate);
                    double hoursDouble = double.Parse(hours);

                    // Create Wages instance
                    Waged wages = new Waged(id,name, address, phoneNumber, sinNum, birthday, department, rateDouble, hoursDouble);

                    // Add to list of employees.
                    employees.Add(wages);
                }
                else if (firstDigitInt >= 8 && firstDigitInt <= 9)
                {
                    // Part time
                    string rate = cells[7];
                    string hours = cells[8];

                    // Convert rate and hours from string to double
                    double rateDouble = double.Parse(rate);
                    double hoursDouble = double.Parse(hours);

                    // Create PartTime instance
                    PartTime partTime = new PartTime(id, name, address, phoneNumber, sinNum, birthday, department, rateDouble, hoursDouble);

                    // Add to list of employees
                    employees.Add(partTime);

                }
            }

            /*if (firstDigit == "0" || firstDigit == "1" || firstDigit == "2" || firstDigit == "3" || firstDigit == "4")
{

}*/

            /**
             * TODO:
             *  - Determine average weekly pay of all employees. - DONE
             *  - Determine highest paid waged employee. - DONE
             *  - Determine lowest paid salaried employee. - DONE
             *  - Determine percentage of employees that are salaried, waged, and part-time.
             */

            double weeklyPaySum = 0;

            // It's okay to use loop through employees multiple times.
            //This look is to calculate the average pay accross all employees
            foreach (Employee employee in employees)
            {
                double weeklyPay = employee.CalcWeeklyPay();

                weeklyPaySum += weeklyPay;
            }

            double averageWeeklyPay = weeklyPaySum / employees.Count;
            Console.WriteLine($"Average weekly pay: {averageWeeklyPay:C}");
            // This loop is to find the highest paid waged employee
            Waged highestPaidWage = null;
            foreach (Employee employee in employees)
            {
                if (employee is Waged)
                {
                   Waged waged = (Waged)employee; 

                    if (highestPaidWage == null || waged.CalcWeeklyPay() > highestPaidWage.CalcWeeklyPay())
                    {
                        highestPaidWage = waged;
                    }
                }
            }
            Console.WriteLine($"Employee {highestPaidWage.Name} is the highest paid for wages ({highestPaidWage.CalcWeeklyPay():C}");
            // This loop is to find the lowest paid Salaried employee
            Salaried lowestSalary = null;
            foreach (Employee employee in employees)
            {
                if (employee is Salaried)
                {
                    Salaried salaried = (Salaried)employee;

                    if (lowestSalary == null || salaried.CalcWeeklyPay() < lowestSalary.CalcWeeklyPay())
                    {
                        lowestSalary = salaried;
                    }
                }
            }
            Console.WriteLine($"Employee {lowestSalary.Name} is the lowest paid salary worker ({lowestSalary.CalcWeeklyPay():C})");
            // The last line here is to figure out the percentage of employees in each category.
            double salaryPercentageCount = 0;
            double wagePercentageCount = 0;
            double partPercentageCount = 0;
            foreach (Employee employee in employees)
            {
                if (employee is Salaried)
                {
                    salaryPercentageCount += 1;
                }
                else if (employee is Waged)
                {
                    wagePercentageCount += 1;
                }
                else if (employee is PartTime)
                {
                    partPercentageCount += 1;
                }
            }
            double salaryPercentage = (salaryPercentageCount / employees.Count);
            double wagePercentage = (wagePercentageCount / employees.Count);
            double partPercentage = (partPercentageCount / employees.Count);

            Console.WriteLine($"Percentage of Salaried employees: {salaryPercentage:P} \n Percentage of Waged employess: {wagePercentage:P} \n percentage of Part time employees: {partPercentage:P}");
        }
    }
}