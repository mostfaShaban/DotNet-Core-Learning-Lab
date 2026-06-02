using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ASS03_OOP
{
    internal class Employee : IComparable
    {

        #region Attributes

        //ID, Name, security level, salary, hire date and Gender
        private int id;
        private string name;
        private SecurityLevel securityLevel;
        private double salary;
        private HireDate hireDate;
        private Gender gender;


        #endregion

        #region Properties

        //full properties
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public SecurityLevel SecurityLevel
        {
            get { return securityLevel; }
            set { securityLevel = value; }
        }

        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public HireDate Hiredate
        {
            get { return hireDate; }
            set { hireDate = value; }
        }

        public Gender Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
            }
        }





        #endregion

        #region Constructors

        public Employee()
        {
            Id = 0;
            Name = "Unknown";
            securityLevel = SecurityLevel.Guest;
            Salary = 0.0;
            Hiredate = new HireDate(1, 1, 2000);
        }
        public Employee(int id, string name, SecurityLevel secLevel, double salary, HireDate hireDate, Gender gender)
        {
            Id = id;
            Name = name;
            securityLevel = secLevel;
            Salary = salary;
            Hiredate = hireDate;
            this.gender = gender;
        }
        #endregion

        #region Methods 
        public override string ToString()
        {
            return string.Format(
                new CultureInfo("en-US"),
                "ID: {0}\nName: {1}\nGender: {2}\nSecurity Level: {3}\nSalary: {4:C}\nHire Date: {5}",
                 Id, Name, gender, securityLevel, Salary, Hiredate
            );
        }

        // Implement IComparable to sort by HireDate
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Employee otherEmp = obj as Employee;
            if (otherEmp != null)
                return this.Hiredate.CompareTo(otherEmp.Hiredate);
            else
                throw new ArgumentException("Object is not an Employee");
        }

        #endregion

    }
}
