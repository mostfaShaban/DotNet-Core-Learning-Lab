namespace Demo
{
	/// 1. Class
	/// 2. Struct
	/// 3. Interface
	/// 4. Enum

    internal class Program
    {
		// 1. Methods 
		// 1.1 Class Member Method [Static Method]
		// 1.2 Object Member Method [Non-Static Method]

		#region Methods
		/// public static void PrintShape()
		/// {
		/// 	for (int i = 1; i <= 5; i++)
		/// 	{
		/// 		Console.Write("*\t");
		/// 	}
		/// }

		public static void PrintShape(int count, string pattern = "$_$")
		//Parameters with default values must come after any required parameters in the method signature.
		{
			for (int i = 1; i <= count; i++)
			{
				Console.Write($"{pattern}\t");
			}
		}
		public static void SWAP(int X, int Y)
		{
			int temp = X;
			X = Y;
			Y = temp;
		}
		public static void SWAP(ref int X, ref int Y)
		{
			int temp = X;
			X = Y;
			Y = temp;
		}
		//public static int SumArray(int[] arr)
		//{
		//	int sum = 0;
		//	if (arr is not null)
		//	{
		//		arr = new int[] { 10, 20, 30, 40 };
		//		for (int i = 0; i < arr.Length; i++)
		//			sum += arr[i];
		//	}
		//	return sum;
		//}
		public static int SumArray(ref int[] arr)
		{
			int sum = 0;
			if (arr is not null)
			{
				arr = new int[] { 10, 20, 30, 40 };
				for (int i = 0; i < arr.Length; i++)
					sum += arr[i];
			}
			return sum;
		}

		///public static int SumSub(int x, int y)
		///{
		///	int sum = x + y;
		///	int sub = x - y;
		///	return sum; return sub; // Unreachable code detected
		///	return new int[] { sum, sub }; // Return Array 
		///	return [sum, sub]; // Return Array [Shorthand]
		///	return new {sum, sub}; // Return object - anonymous type (Compiler Will Generate Class in Runtime)
		///}

		public static void SumSub(int x, int y, out int sum, out int sub)
		{
			sum = x + y;
			sub = x - y;
		}
		public static int SumArray(params int[] Arr)
		{
			int sum = 0;
			if (Arr is not null)
			{
				for (int i = 0; i < Arr.Length; i++)
					sum += Arr[i];
			}
			return sum;
		}
		public static void Concat<T>(params ReadOnlySpan<T> items)
		{
			for (int i = 0; i < items.Length; i++)
			{
				Console.Write($"{items[i]} ");
			}
		} 
		#endregion

		static void Main(string[] args)
		{
			#region Array Methods 
			//int[] numbers = { 5, 3, 4, 1, 2, 4 };
			//Array.Sort(numbers); //  1, 2, 3, 4,4, 5
			//Array.Reverse(numbers); // 4, 2, 1, 4, 3, 5
			//Array.Clear(numbers); // 0,0,0,0,0,0
			//Array.Clear(numbers, 2, 2); // 5,3,0,0,2 ,4
			//Console.WriteLine(Array.IndexOf(numbers, 4)); // 2
			//Console.WriteLine(Array.LastIndexOf(numbers, 4)); // 5
			//Array.Resize(ref numbers, 10); // 5, 3, 4, 1, 2, 4 , 0 ,0,0,0


			//foreach (int num in numbers)
			//{
			//	Console.WriteLine(num);
			//}

			//int[] Arr01 = { 1, 2, 3, 4, 5 };
			//int[] Arr02 = new int[4];
			////Array.Copy(Arr01, Arr02, 4); // 1, 2, 3, 4
			//Array.ConstrainedCopy(Arr01, 1, Arr02, 1, 2); // 0,2,3,0
			//foreach (int num in Arr02)
			//{
			//	Console.WriteLine(num);  
			//}
			#endregion

			#region Functions 

			#region Function Prototype
			///////*Program.*/PrintShape(); // *      *      *      *      *
			////PrintShape(15 , ":)");  // Passing Parameters By Order
			////PrintShape(pattern : "*_*" , count : 10); // Passing Parameters By Name
			//////PrintShape(); // Using Default Values 
			//////PrintShape(pattern : "*_*"); // Using Default Value of Count 
			////PrintShape(4); // Using Default Values 
			///////  /*\
			////PrintShape ("/*\"); // Invalid [ Escape Sequences]


			//Console.WriteLine("Welcome Aliaa \rHello Amr"); // Hello Amrliaa
			//Console.WriteLine("Hello\bWorld!"); 
			//Console.WriteLine(@"Hello\World!");
			//int X = 10;
			//Console.WriteLine($"Hello {X} World!");  // Hello 10 World!
			//Console.WriteLine($"Hello {{X}} World!");// Hello {X} World!
			//Console.WriteLine("Name:Aliaa\tAge:25"); // Name:Aliaa      Age:25
			//										 /////  /*\

			//PrintShape(10 , "/*\\"); 
			#endregion

			#region Function Parameters [Value Type]

			#region Passing by Value 
			//int A = 10, B = 5;
			//Console.WriteLine($"A = {A}"); // 10
			//Console.WriteLine($"B = {B}"); // 5
			//SWAP(A, B); // Passing By Value
			//Console.WriteLine("After Swapping");
			//Console.WriteLine($"A = {A}"); // 10
			//Console.WriteLine($"B = {B}"); // 5 
			#endregion

			#region Passing By Reference 

			//int A = 10, B = 5;
			//Console.WriteLine($"A = {A}"); // 10
			//Console.WriteLine($"B = {B}"); // 5
			//SWAP(ref A, ref B); // Passing By Reference
			//Console.WriteLine("After Swapping");
			//Console.WriteLine($"A = {A}"); // 5
			//Console.WriteLine($"B = {B}"); // 10

			#endregion

			#endregion

			#region Function Parameters [Reference Type]

			#region Example 01 

			#region Passing By Value
			//int[] numbers = { 1, 2, 3 };
			//int result = SumArray(numbers); // Passing By Value [Address]
			//Console.WriteLine(numbers.GetHashCode());
			//Console.WriteLine($"Sum =  {result}"); // 105
			//Console.WriteLine($"Numbers[0] = {numbers[0]}"); // 100


			#endregion

			#region Passing by Reference 
			//int[] numbers = { 1, 2, 3 };
			//int result = SumArray(ref numbers); // Passing By Reference [Reference of Array : numbers]
			//Console.WriteLine($"Sum =  {result}"); // 105
			//Console.WriteLine($"Numbers[0] = {numbers[0]}"); // 100
			#endregion

			#endregion

			#region Example 02 

			#region Passing By Value

			//int[] numbers = { 1, 2, 3 };
			//int result = SumArray(numbers); // Passing By Value [Address]
			//Console.WriteLine($"Sum =  {result}"); // 100
			//Console.WriteLine($"Numbers[0] = {numbers[0]}"); // 1

			#endregion

			#region Passing by Reference 

			//int[] numbers = { 1, 2, 3 };
			//int result = SumArray(ref numbers); // Passing By Reference [Reference of array [numbers]]
			//Console.WriteLine($"Sum =  {result}"); // 100
			//Console.WriteLine($"Numbers[0] = {numbers[0]}"); // 10

			#endregion

			#endregion

			#endregion

			#region Function Parameters [Passing By out]


			//int a = 10, b = 3, SumResult, SubResult;

			//SumSub(a, b, out SumResult, out SubResult); // Passing By Out
			//Console.WriteLine($"Sum Result = {SumResult}"); // 13
			//Console.WriteLine($"Sub Result = {SubResult}"); // 7

			#endregion

			#region Function Parameters [Params]
			#region Before C# 13
			//int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			//int Result = SumArray(1, 2, 3, 4, 5, 6, 7, 8, 9); //C# will convert it to an array internally
			//Console.WriteLine($"Sum = {Result}"); // 45
			//string message = string.Format("Hello {0} Your Age is {1}", "Aliaa", 26); //Hello Aliaa Your Age is 26
			//Console.WriteLine(message); 
			#endregion

			#region After C# 13 

			//Concat<object>("Hello Ahmed", "Welcome To Route", "Your Number Is", 123456 , "Data is" , DateTime.Now);
			//// Hello Ahmed Welcome To Route Your Number Is 123456 Data is 12/18/2024 5:35:22 PM

			#endregion

			#endregion

			#endregion

			#region Boxing , Unboxing 

			#region Boxing [Value Type => Reference Type]

			//int X = 100;

			//object obj = X; // Boxing 
			//				// Take Copy From Value and Wrapping the value in an object
			//obj = 1.2;    // Casting From  double  [valuetype] => To Object [Reference Type] ----> Boxing
			//obj = 'A';    // Casting From  char    [valuetype] => To Object [Reference Type] ----> Boxing
			//obj = 5.2f;   // Casting From  float   [valuetype] => To Object [Reference Type] ----> Boxing
			//obj = true;   // Casting From  bool    [valuetype] => To Object [Reference Type] ----> Boxing
			//obj = 1.2m;   // Casting From  decimal [valuetype] => To Object [Reference Type] ----> Boxing
			//			  // Implicit Casting 
			//			  // Safe Casting 

			//Console.WriteLine(obj); // 1.2 

			//obj = (object)'B'; // Boxing

			#endregion

			#region Unboxing [Reference Type => Value Type]

			//object obj = "Aliaa";
			//obj = new int[] { 1, 2, 3 };

			//int X = (int)obj;      // Casting From  Object [Reference Type] => To int [ValueType] ----> Unboxing
			//char input = (char)obj; // Casting From  Object [Reference Type] => To char [ValueType] ----> Unboxing
			//bool flag = (bool)obj;  // Casting From  Object [Reference Type] => To bool [ValueType] ----> Unboxing
			//						// Explicit Casting
			//						// Unsafe Casting 


			//Console.WriteLine(flag); //InvalidCastException:
			#endregion

			#endregion

			#region Nullable value types

			#region Example 01
			//int X = 10;
			////X = null; // Invalid

			//Nullable<int> Y = 50;
			//Y = null; // Valid 

			//int? Z = 100;
			//Z = null; 
			#endregion

			#region Example 02 [Casting From nullable type to non-nullable type]

			//int X = 10;
			//int? Y = X; // Valid implicitly Casting

			//int? A = 10;
			//int B = (int)A; // Explicitly Casting 

			//A = null;
			//if (A is not null) B = (int)A;
			//else B = 0;

			//if (A.HasValue) B = A.Value;
			//else B = 0;

			//B = A.HasValue ? A.Value : 0;

			//      B = A ?? 0; //null-coalescing operator

			//   B = A.GetValueOrDefault();


			//Console.WriteLine(A); // null
			//Console.WriteLine(B); // 0

			#endregion

			#endregion

			#region Nullable Reference Types 

			//         #nullable disable

			//string name01 = null;
			//Console.WriteLine(name01);

			//         #nullable enable
			//string? name02 = null;
			//Console.WriteLine(name02);

			//string name03 = null!; 
			////use the null-forgiving operator to suppress all nullable warnings for the expression.
			//Console.WriteLine(name03);

			#endregion

			#region Null-Conditional | Propagation operator

			//int[]? numbers = null;

			////int arraylength = numbers?.Length ?? 0;

			////int? Nullablearraylength = numbers?.Length;

			////Console.WriteLine(arraylength);

			//for (int i = 0; i < numbers?.Length; i++)
			//{
			//	Console.WriteLine(numbers[i]);
			//}

			//Console.WriteLine("==============================");

			//if (numbers != null)
			//{
			//	for (int i = 0; i < numbers.Length; i++)
			//	{
			//		Console.WriteLine(numbers[i]);
			//	}
			//}
			//else
			//{
			//	// Need Additional Action to Be Executed
			//}

			#endregion

		}
	}
}
