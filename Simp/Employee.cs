using System;
using System.Collections.Generic;
using System.Text;

namespace Simp
{
    public class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int HireYear { get; set; }

        public Employee(int id, string firstName, string lastName, int hireYear)
        {
            //id = ID;
            //firstName = FirstName;
            //lastName = LastName;
            //hireYear = HireYear;

            this.ID = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.HireYear = hireYear;
        }

        public Employee()
        {

        }

        public override string ToString()
        {
            return $"ID: {ID} First Name: {FirstName} Last Name: {LastName} Hire Year: {HireYear}";
        }
    }
}
