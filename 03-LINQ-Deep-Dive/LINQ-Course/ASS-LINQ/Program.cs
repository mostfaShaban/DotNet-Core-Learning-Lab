using  Demo;
using Demo.Data;
using System.Diagnostics.Metrics;
using System.Runtime.Intrinsics.Arm;
using System.Threading;
using static Demo.ListGenerator;
namespace ASS_LINQ
{
    internal class Program
    {

        static void PrintCollection<T>(IEnumerable<T> collection)
        {

            foreach (var item in collection)
            {
                Console.WriteLine(item?.ToString());
            }

            Console.WriteLine("----------------");
        }
        static void Main(string[] args)
        {
            #region ASS#01

            #region Part01
            #region 1. Find all products that are out of stock.

            //var Result = ProductsList.Where(P => P.UnitsInStock == 0);

            //Result=from P in ProductsList
            //       where P.UnitsInStock == 0
            //       select P;
            //PrintCollection(Result);


            #endregion

            #region 2. Find all products that are in stock and cost more than 3.00 per unit.

            //var Result = ProductsList.Where(P => P.UnitsInStock > 0 && P.UnitPrice> 3.00M);

            //Result = from P in ProductsList
            //         where P.UnitsInStock >0 && P.UnitPrice > 3.00M
            //         select P;


            //PrintCollection(Result);

            #endregion

            #region 3. Returns digits whose name is shorter than their value.

            //String[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            //var Result = Arr.Where((P, I) => P.Length < I);

            //var Result0 = (from item in Arr.Select((A, I) => new { Word = A, Index = I })
            //             where item.Word.Length < item.Index
            //             select new { item.Word, item.Index });
            //PrintCollection(Result0);

            #endregion

            #region 4. Get first Product out of Stock 

            //var Result = ProductsList.FirstOrDefault(P => P.UnitsInStock == 0);

            //Result = (from P in ProductsList
            //                where P.UnitsInStock == 0
            //                select P).FirstOrDefault();

            //Console.WriteLine(Result);

            #endregion

            #region 5.Return the first product whose Price > 1000, unless there is no match, in which case null is returned.

            //var Result05 = ProductsList.FirstOrDefault(P => P.UnitPrice > 1000M);


            //Console.WriteLine(Result05 != null ? Result05.ToString() : "No product found with price > 1000");



            #endregion

            #region 6. Retrieve the second number greater than 5 

            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var Result06 = Arr.Where(N => N > 5) 
            //      .Skip(1)           
            //      .FirstOrDefault(); 

            //Console.WriteLine($"The second number greater than 5 is: {Result06}");


            #endregion
            #endregion

            #region Part02
            #region 1. Uses Count to get the number of odd numbers in the array
            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //int oddCount = Arr.Count(N => N % 2 != 0);

            //Console.WriteLine($"Number of odd numbers: {oddCount}");



            #endregion

            #region 2.Return a list of customers and how many orders each has.

            //var CustomerOrdersCount = CustomersList.Select(C => new
            //{
            //    CustomerName = C.CustomerName,
            //    OrderCount = C.Orders != null ? C.Orders.Length : 0 
            //});

            //PrintCollection(CustomerOrdersCount); 
            #endregion

            #region 3. Return a list of categories and how many products each has

            //var CustomerOrdersCount = ProductsList.GroupBy(P => P.Category).Select(P => new
            //{
            //    CategoryName = P.Key,
            //    OrderCount = P.Count()
            //});

            //PrintCollection(CustomerOrdersCount);



            #endregion

            #region 4. Get the total of the numbers in an array.
            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //int totalSum = Arr.Sum();
            //Console.WriteLine($"Total sum of numbers: {totalSum}"); 
            #endregion

            //string[] words = File.ReadAllLines("dictionary_english.txt");

            #region 5. Get the total number of characters of all words in dictionary_english.txt



            //int totalChars = words.Sum(w => w.Length);
            //Console.WriteLine($"Total characters in dictionary: {totalChars}"); 

            #endregion

            #region 6. Get the length of the shortest word in dictionary_english.txt
            //int shortestWordLength = words.Min(w => w.Length);
            //Console.WriteLine($"Length of the shortest word: {shortestWordLength}");

            #endregion

            #region 7. Get the length of the longest word in dictionary_english.txt

            //int longestWordLength = words.Max(w => w.Length);
            //Console.WriteLine($"Length of the longest word: {longestWordLength}");
            #endregion

            #region 8. Get the average length of the words in dictionary_english.txt

            //double averageLength = words.Average(w => w.Length);
            //Console.WriteLine($"Average word length: {averageLength:F2}");
            #endregion
            #endregion

            #region Part03

            ////1. Sort a list of products by name
            //var SortedProductsByName = ProductsList.OrderBy(P => P.ProductName);
            //PrintCollection(SortedProductsByName);


            ////2. Uses a custom comparer to do a case-insensitive sort of the words in an array.
            //String[] Arr02 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            //var CaseInsensitiveSort = Arr02.OrderBy(W => W, StringComparer.OrdinalIgnoreCase);
            //PrintCollection(CaseInsensitiveSort);


            ////3. Sort a list of products by units in stock from highest to lowest.
            //var SortedByStockDescQuery = from P in ProductsList
            //                             orderby P.UnitsInStock descending
            //                             select P;
            //PrintCollection(SortedByStockDescQuery);

            ////4. Sort a list of digits, first by length of their name, and then alphabetically by the name itself.
            //string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            //var SortedDigits = Arr.OrderBy(D => D.Length)
            //                        .ThenBy(D => D); 

            //PrintCollection(SortedDigits);



            ////5. Sort first by-word length and then by a case-insensitive sort of the words in an array.

            //String[] Arr05 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            //var SortedArr05Query = (from W in Arr05 orderby W.Length select W)
            //           .ThenBy(W => W, StringComparer.OrdinalIgnoreCase);

            //PrintCollection(SortedArr05Query);


            ////6. Sort a list of products, first by category, and then by unit price, from highest to lowest.
            //var SortedProductsMixed = ProductsList.OrderBy(P => P.Category)
            //                          .ThenByDescending(P => P.UnitPrice);

            //PrintCollection(SortedProductsMixed);

            ////7. Sort first by-word length and then by a case-insensitive descending sort of the words in an array.
            //String[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            //var SortedArr = Arr.OrderBy(A => A.Length)
            //                    .ThenByDescending(W => W, StringComparer.OrdinalIgnoreCase);
            // SortedArr = (from W in Arr orderby W.Length select W)
            //           .ThenByDescending(W => W, StringComparer.OrdinalIgnoreCase);

            //PrintCollection(SortedArr);


            ////8.Create a list of all digits in the array whose second letter is 'i' that is reversed
            ////from the order in the original array.
            //string[] Arr = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];

            //var ListArr = Arr.Where(A => A.Length > 1 && A[1] == 'i').Reverse();
            //PrintCollection(ListArr);




            #endregion

            #region Part04_Transformation Operators

            ////1. Return a sequence of just the names of a list of products.
            //var ProductNames = ProductsList.Select(P => P.ProductName);

            //PrintCollection(ProductNames);

            //// 2.Produce a sequence of the uppercase and lowercase versions of each word in the original array(Anonymous Types).

            // String[] wordsQuery = { "aPPLE", "BlUeBeRrY", "cHeRry" };

            // var UpperLowerWordsQuery = from W in wordsQuery
            //                            select new
            //                            {
            //                                Upper = W.ToUpper(),
            //                                Lower = W.ToLower()
            //                            };

            // PrintCollection(UpperLowerWordsQuery);


            ////3.Produce a sequence containing some properties of Products, including UnitPrice
            ////which is renamed to Price in the resulting type.

            //var ProductProperties = ProductsList.Select(P => new
            //{
            //    Id = P.ProductID,
            //    Name = P.ProductName,
            //    Price = P.UnitPrice 
            //});

            //PrintCollection(ProductProperties);



            ////4. Determine if the value of int in an array matches their position in the array.

            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var InPlaceCheck = Arr.Select((Num, Index) => new
            //{
            //    Number = Num,
            //    InPlace = (Num == Index) 
            //});

            //Console.WriteLine("Number: In-place?");
            //foreach (var item in InPlaceCheck)
            //{
            //    Console.WriteLine($"{item.Number}: {item.InPlace}");
            //}

            ////5. Returns all pairs of numbers from both arrays such that the number from numbersA is less than the number from numbersB.
            //int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            //int[] numbersB = { 1, 3, 5, 7, 8 };

            //var PairsQuery = from a in numbersA
            //                 from b in numbersB
            //                 where a < b
            //                 select new { a, b };

            //Console.WriteLine("Pairs where a < b:");
            //foreach (var pair in PairsQuery)
            //{
            //    Console.WriteLine($"{pair.a} is less than {pair.b}");
            //}


            ////6. Select all orders where the order total is less than 500.00.
            //var LowTotalOrdersFluent = CustomersList.SelectMany(C => C.Orders)
            //                                        .Where(O => O.Total < 500.00M);

            //PrintCollection(LowTotalOrdersFluent);

            //7. Select all orders where the order was made in 1998 or later.
            //var RecentOrdersQuery = from C in CustomersList
            //                        from O in C.Orders     
            //                        where O.OrderDate.Year >= 1998 
            //                        select O;

            //PrintCollection(RecentOrdersQuery);





            #endregion

            #endregion
        }
    }
}
