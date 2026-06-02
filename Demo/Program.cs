using Common;

namespace Demo
{

	internal class Program
	{
		static void Main(string[] args)
		{

			#region Access Modifiers [Private - Internal - Public]
			// TypeA typeA = new TypeA();
			////typeA.X = 1;// Invalid  // X is private [assessable within its Scope Only ]
			////typeA.Y = 1; // Invalid // Y is Internal [assessable within its Scope and in Same Project Only] 
			//typeA.Z = 1; // Valid // Z is Public [assessable within its Scope , in Same Project and outside project]
			#endregion

			#region Enum

			#region Example 01
			//Person person = new Person();
			//person.Id = 10;
			//person.Name = "Amr";
			//person.Gender = Gender.Male;

			//Grades Grd01 = Grades.A;

			////if (Grd01 == Grades.A)
			////	Console.WriteLine("Bravo");
			////else
			////	Console.WriteLine(":(");

			//Grd01 = (Grades) 4;
			//Console.WriteLine(Grd01); // E


			//Gender Gen01 = new Gender();
			//Console.WriteLine(Gen01); // Male



			//Student student = new Student()
			//{
			//	Id = 1,
			//	Name = "Eman",
			//	Branch = Branch.Dokki, // 10
			//	Gender = Gender.Female, // 1
			//	Grades = Grades.B // 1
			//}; 
			#endregion

			#region Example 02
			/// Take Data Of Student From User 
			/// Then Print Message 

			//Student student = new Student();
			//bool isParsed;
			//Console.WriteLine("Please Enter Student Data :");
			//Console.Write("ID : ");
			//int id;
			//do { isParsed = int.TryParse(Console.ReadLine(), out id); } while (!isParsed);
			//student.Id = id;

			//Console.Write("Name : ");
			//student.Name = Console.ReadLine();

			////student.Gender = Console.ReadLine(); // Invalid 
			//Object stdGender;
			//do
			//{
			//	Console.Write("Gender : ");
			//	isParsed = Enum.TryParse(typeof(Gender), Console.ReadLine(), out  stdGender);
			//} while (!isParsed || stdGender is null);
			//student.Gender = (Gender)stdGender;

            //Generic TryParse

            //do
            //{
            //	Console.Write("Branch : ");
            //	isParsed = Enum.TryParse<Branch>(Console.ReadLine(), out Branch stdBranch);//<Branch>
            //	student.Branch = stdBranch;
            //} while (!isParsed);

            //do
            //{
            //	Console.Write("Grade : ");
            //	isParsed = Enum.TryParse(Console.ReadLine(), out Grades stdGrade);
            //	student.Grades = stdGrade;
            //} while (!isParsed);

            //Console.Clear();
            //Console.WriteLine($"Hello {student.Name} Welcome To Route\nYour Branch is {student.Branch} And Your Grade is {student.Grades}");


            #endregion

            #region Example 03 - Permissions

            ////User user01 = new User();
            ////user01.Id = 10; // 4 Bytes 
            ////user01.Permissions[0] = true; // Write 
            ////user01.Permissions[1] = false; // Read 
            ////user01.Permissions[2] = true; // Execute 
            ////user01.Permissions[3] = false; // Delete 
            ////// User Data Stored in 8 Bytes 

            //User user02 = new User();
            //user02.Id = 20;
            //user02.Permissions = Permission.Write; 

            //User user03 = new User();
            //user03.Id = 30;
            //user03.Permissions = (Permission)4; // Read
            //user03.Permissions = (Permission)10; // Execute and Write 

            //user03.Permissions = (Permission)3; // Delete And Execute 
            //Console.WriteLine(user03.Permissions); // Delete ,Execute

            //// Add Permission Read to User 
            //user03.Permissions = user03.Permissions ^ Permission.Read;
            //Console.WriteLine(user03.Permissions); // Delete, Execute, Read


            //// Deny Permission Read to User 
            //user03.Permissions = user03.Permissions ^ Permission.Read;
            //Console.WriteLine(user03.Permissions); // Delete, Execute


            //// Deny All Permissions to User Except Delete
            //user03.Permissions = user03.Permissions & Permission.Delete;
            //Console.WriteLine(user03.Permissions); // Delete


            //// Check is User Has Permission Execute Permission or not 
            //if ( (user03.Permissions & Permission.Execute) == Permission.Execute)
            //	Console.WriteLine("User Has Execute Permission");
            //else
            //	Console.WriteLine("User Hasn't Execute Permission");

            //Console.WriteLine(user03.Permissions); // Delete


            //// Check is User Has Permission Execute Permission or not if not add it to him/her
            //if ((user03.Permissions & Permission.Execute) == Permission.Execute)
            //	Console.WriteLine("User Has Execute Permission");
            //else
            //	user03.Permissions = user03.Permissions ^ Permission.Execute;

            //Console.WriteLine(user03.Permissions); // Delete , Execute

            //// Check is User Has Permission Delete Permission or not if not add it to him/her
            //user03.Permissions = user03.Permissions | Permission.Delete;
            //Console.WriteLine(user03.Permissions); // Delete , Execute

            //// Check is User Has Permission Read Permission or not if not add it to him/her
            //user03.Permissions = user03.Permissions | Permission.Read;
            //Console.WriteLine(user03.Permissions); // Delete ,Execute, Read

            #endregion

            #endregion

            #region Struct 

            #region Example 01
            //Point P1;
            //// Declare variable | Object From Type 'Point' 
            //// CLR Will Allocate 8 Unitintialized Bytes At Stack 

            //P1 = new Point();
            //// New Is Just For Constructor Selection That Will Used To Initialize P1 Attribute 
            //Console.WriteLine($"P1.X = {P1.x}"); // 0
            //Console.WriteLine($"P1.Y = {P1.y}"); // 0


            //P1 = new Point(10, 20);

            //P1 = new (10, 20); // Syntax Sugar 
            //Console.WriteLine($"P1.X = {P1.x}"); // 10
            //Console.WriteLine($"P1.Y = {P1.y}"); // 20


            //Console.WriteLine(P1); // (10 , 20)
            //Console.WriteLine(P1.ToString()); // (10 , 20) 
            #endregion

            #region Example 02

            //Point P1 = new Point(1 , 2);
            //Console.WriteLine($"P1.X = {P1.x}"); // 1 
            //Console.WriteLine($"P1.Y = {P1.y}"); // 2

            //Point P2 =	new Point(10 , 20);
            //Console.WriteLine($"P2.X = {P2.x}"); // 10 
            //Console.WriteLine($"P2.Y = {P2.y}"); // 20

            //P2 = P1;

            //Console.WriteLine("After Assign P2 = P1");
            //Console.WriteLine($"P1.X = {P1.x}"); // 1 
            //Console.WriteLine($"P1.Y = {P1.y}"); // 2
            //Console.WriteLine($"P2.X = {P2.x}"); // 1 
            //Console.WriteLine($"P2.Y = {P2.y}"); // 2

            //P1.x = 100;
            //P1.y = 200;

            //Console.WriteLine("After Changing P1 ");
            //Console.WriteLine($"P1.X = {P1.x}"); // 100 
            //Console.WriteLine($"P1.Y = {P1.y}"); // 200
            //Console.WriteLine($"P2.X = {P2.x}"); // 1 
            //Console.WriteLine($"P2.Y = {P2.y}"); // 2

            #endregion

            #endregion

        }
    }
}
