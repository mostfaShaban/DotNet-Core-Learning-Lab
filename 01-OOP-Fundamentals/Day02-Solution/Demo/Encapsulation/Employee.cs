using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Encapsulation
{
	internal struct Employee
	{
		public int EmpId;
		private string? Name;

		// Encapsulation 
		// Separate Data Definition [Attributes] From Its Use [Getter Setter , Property]

		#region 01 Applying Encapsulation using [Getter Setter Approach]

		public string? GetName()
		{
			return Name;
		}

		public void SetName(string? value)
		{
			Name = value?.Length > 10 ? value.Substring(0, 10) : value;
		}

		#endregion


		#region 02 Applying Encapsulation Using [Property] 
		// Using This Approach is Recommended => Easy To Use Like Attributes

		private decimal salary;
        // 02.1 Full Property 

        public decimal Salary
        {
            get
            {
                return salary;
            }
            set
            {
                salary = value < 10000 ? 10000 : value;
            }
        }

        // 02.2 Automatic Property 
        public int Age { get; set; }
        
        // Compiler Will Generate Backing Field "Private Hidden Attribute"


        //private decimal deduction; // Derived Attribute
        public decimal Deduction // Read Only Property 
		{
			get
			{
				return salary * 0.1M;
			}
			//set
			//{
			//	deduction = value; 
			//}
		}

		// Code Snippet Prop 
		public int MyProperty { get; set; }

		// Code Snippet PropFull 
		private int myVar;
		public int MyProperty02
		{
			get { return myVar; }
			set { myVar = value; }
		}

		#endregion
		public Employee(int id, string? name, decimal salary , int age)
		{
			EmpId = id;
			Name = name;
			this.salary = salary;
			Age = age;
		}

		public override string ToString()
		{
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            return $"Id : {EmpId}\nName : {Name}\nSalary : {salary:c}";
		}
	}
}
