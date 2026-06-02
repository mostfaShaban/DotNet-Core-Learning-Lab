namespace Ass01_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 1-write a C# program that prints out all the days of the week using this Enum.

            //Console.WriteLine("Days of the week:");
            //foreach (WeekDays day in Enum.GetValues(typeof(WeekDays)))
            //{
            //    Console.WriteLine(day);
            //}



            #endregion

            #region 2 - Write a C# program that takes a season name as input from the user and displays the corresponding month range for that season

            //Console.WriteLine("Enter a season name (Spring, Summer, Autumn, Winter):");
            //string ?input = Console.ReadLine();

            //if (Enum.TryParse< Seas_on > (input, true, out Seas_on selectedSeason))
            //{
            //    // 3. عرض نطاق الأشهر بناءً على الفصل المختار
            //    string monthRange = selectedSeason switch
            //    {
            //        Seas_on.Spring => "March to May",
            //        Seas_on.Summer => "June to August",
            //        Seas_on.Autumn => "September to November",
            //        Seas_on.Winter => "December to February",
            //        _ => "Unknown"
            //    };

            //    Console.WriteLine($"The month range for {selectedSeason} is: {monthRange}");
            //}
            //else
            //{
            //    Console.WriteLine("Invalid input! Please enter a valid season name.");
            //}





            #endregion

            #region 3 -Create Variable from previous Enum to Add and Remove Permission from variable, check if specific Permission existed inside variable

            //Permissions per = new Permissions();
            //per = (Permissions)2;
            //Console.WriteLine($"Initial Permissions: {per}");
            //per ^= Permissions.Read;// add Read permission
            //Console.WriteLine($"Permissions after adding Read: {per}");
            //per ^= Permissions.Read;// remove Read permission
            //Console.WriteLine($"Permissions after removing Read: {per}");

            //per= per | Permissions.Execute;// add Execute permission
            //Console.WriteLine($"Permissions after adding Execute: {per}");
            ////check if Execute permission exists
            //bool hasExecute = (per & Permissions.Execute) == Permissions.Execute;
            //Console.WriteLine($"Does the variable have Execute permission? {hasExecute}");
            ////check if Execute permission exists by And operator
            //bool hasExecuteAnd = (per & Permissions.Execute) != 0;
            //Console.WriteLine($"Does the variable have Execute permission (using AND operator)? {hasExecuteAnd}");





            #endregion

            #region C# program that takes a color name as input from the user and displays a message indicating whether the input color is a primary color or not.

            //Console.WriteLine("Enter a color name (Red, Green, Blue):");
            //string ?colorInput = Console.ReadLine();

            //if (Enum.TryParse<Colors>(colorInput, true, out Colors selectedColor))
            //{
            //    // إذا نجح التحويل، فهذا يعني أن اللون موجود في الـ Enum (لون أساسي)
            //    Console.WriteLine($"{selectedColor} is a primary color.");
            //}
            //else
            //{
            //    // إذا فشل التحويل، فاللون ليس من ضمن الألوان الأساسية المعرفة
            //    Console.WriteLine($"{colorInput} is NOT a primary color.");
            //}

            #endregion
        }
    }
} 
