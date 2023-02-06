using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Entities
{
    /// <summary>
    /// Represents an Employee
    /// </summary>
    /// <remarks>Author: Nick Hamnett</remarks>
    /// <remarks>Date: January 27, 2023</remarks>
    internal class Employee
    {
		// TODO: Add remaining fields, properties, and constructor parameters for general employee.
        protected string id;
        protected string name;
        protected string address;
        // These are the remaining fields
        protected string phoneNumber;
        protected long sinNum;
        protected string birthday;
        protected string department;

        public string ID { get { return id; } }
        public string Name { get { return name; } }
        public string Address { get { return address; } }
        // These are the new ones added in
        public string PhoneNumber { get { return phoneNumber; } }
        public long SinNum { get { return sinNum; } }
        public string Birthday { get { return birthday; } }
        public string Department { get { return department; } }

        /// <summary>
        /// No-arg constructor
        /// </summary>
        public Employee() { }

        /// <summary>
        /// User-defined constructor
        /// </summary>
        /// <param name="id">Employee ID</param>
        /// <param name="name">Name of employee</param>
        /// <param name="address">Employee's address</param>
        /// <param name="phoneNumber">Employee's Phonenumber</param>
        /// <param name="sinNum">Employee's Sin Number</param>
        /// <param name="birthday">Employee's date of birth</param>
        /// <param name="department">Which department the employee works in</param>
        public Employee(string id, string name, string address, string phoneNumber, long sinNum, string birthday, string department)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.sinNum = sinNum;
            this.birthday = birthday;
            this.department = department;
        }

        public virtual double CalcWeeklyPay()
        {
            return 0;
        }
    }
}
