using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Entities
{
    /// <summary>
    /// Represents a part-time employee
    /// </summary>
    /// <remarks>Author: Nick Hamnett</remarks>
    /// <remarks>Date: January 27, 2023</remarks>
    internal class PartTime : Employee
    {
		// TODO: Add remaining fields, properties, and constructor parameters for part-time employee.
        private double rate;
        private double hours;
        public double Rate { get {  return rate; } }
        public double Hours { get { return hours; } }
        // This is how ID, name, and address would be set if the fields in the Employee class are private and it couldn't be modified.
        /*public PartTime(string id, string name, string address, double rate) : base(id, name, address)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.rate = rate;
        }*/

        /// <summary>
        /// User-defined constructor
        /// </summary>
        /// <param name="id">Employee ID</param>
        /// <param name="name">Name of employee</param>
        /// <param name="address">Employee's address</param>
        /// 
        /// <param name="phoneNumber">Employee's Phonenumber</param>
        /// <param name="sinNum">Employee's Sin Number</param>
        /// <param name="birthday">Employee's date of birth</param>
        /// <param name="department">Which department the employee works in</param>
        /// <param name="rate">Employee's rate</param>
        /// <param name="hours">Employee's hours</param>
        public PartTime(string id, string name, string address, string phoneNumber, long sinNum, string birthday, string department, double rate, double hours)
        {
            // Set in instance of inherited Employee
            this.id = id;
            this.name = name;
            this.address = address;

            this.phoneNumber = phoneNumber;
            this.sinNum = sinNum;
            this.birthday = birthday;
            this.department = department;
            // Set in instance of this class
            this.rate = rate;
            this.hours = hours;
        }
        public override double CalcWeeklyPay()
        {
            double weeklyPay = 0;
            weeklyPay = this.rate * this.hours;
            return weeklyPay;
        }
    }
}
