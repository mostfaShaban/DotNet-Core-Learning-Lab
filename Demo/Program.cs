using Demo.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static Demo.ListGenerator;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine(ProductsList[0]);
            //Console.WriteLine(CustomersList[1]);

            #region Filtartion Operators [Where]
            #region EX01
            ////1.Get product out of Stock
            ////fluent Syntax
            //var Result = ProductsList.Where(P => P.UnitsInStock == 0);
            //foreach (var Product in Result)
            //{
            //    Console.WriteLine(Product);
            //}
            ////Query Syntax
            //Result = from P in ProductsList
            //       where P.UnitsInStock == 0
            //       select P; 
            #endregion

            #region Ex02
            ////2. Get Elements In Stock And In Category Of Meat/Poultry
            ////fluent Syntax
            //var Result2 = ProductsList.Where(P => P.UnitsInStock > 0 && P.Category == "Meat/Poultry");
            //foreach (var Product in Result2)
            //{
            //    Console.WriteLine(Product);
            //}
            ////Query Syntax
            //Result2= from P in ProductsList
            //         where P.UnitsInStock > 0 && P.Category == "Meat/Poultry"
            //         select P; 
            #endregion

            //Indexed Where
            #region EX03
            ////3.Get Elements Out Of Stock In First 10 Elements
            ////fluent Syntax 
            //var Result3 = ProductsList.Where((P, Index) => P.UnitsInStock == 0 && Index < 10);
            //foreach (var item in Result3)
            //{
            //    Console.WriteLine(item);
            //}
            ////Indexed Where valid only fluent Syntax ,not can't use by Query Syntax

            #endregion

            #endregion

            #region Transformation [Projection] Operators [Select , Select Many]

            #region Select Product Name
            ////fluent Syntax
            //var result = ProductsList.Select(P => P.ProductName);

            ////Query Syntax
            //result = from P in ProductsList
            //         select P.ProductName;



            #endregion

            #region Select Customer Name
            ////fluent Syntax
            //var result = CustomersList.Select(C=>C.CustomerName);

            ////Query Syntax
            //result=from C in CustomersList
            //         select C.CustomerName;
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

            #region Select Customer Orders[SelcetMany]
            //fluent Syntax
            //var result = CustomersList.SelectMany(C => C.Orders);

            ////Query Syntax
            //var result = from C in CustomersList
            //         from O in C.Orders
            //         select O;
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}


            #endregion

            #region Select Product Id and Product Name [ Anontmous obj]
            ////fluent Syntax
            //var result = ProductsList.Select(P => new{ Product_ID=P.ProductID, P.ProductName});
            ////CLR Will Create  Class in Runtime and override Tostring

            ////Query Syntax
            //result = from P in ProductsList
            //         select new
            //         {
            //             Product_ID = P.ProductID,
            //             P.ProductName
            //         };


            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Select Product In Stock And Apply Discount 10 % On Its Price [ Anontmous obj]

            ////Fluent Syntax
            //var result = ProductsList.Where(P => P.UnitsInStock > 0)
            //               .Select(P => new
            //               {
            //                   ID = P.ProductID,
            //                   Name = P.ProductName,
            //                   OldPrice = P.UnitPrice,
            //                   NewPrice = P.UnitPrice - (P.UnitPrice * 0.1M),
            //               });

            ////Query Syntax
            //var result = from P in ProductsList
            //             where P.UnitsInStock>0
            //             select new
            //             {
            //                 ID = P.ProductID,
            //                 Name = P.ProductName,
            //                 OldPrice = P.UnitPrice,
            //                 NewPrice = P.UnitPrice - (P.UnitPrice * 0.1M),
            //             };

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}



            #endregion

            #region Indexed Select => Valid only with Fluent Syntax

            ////Select Product In Stock And Return Product Name and index of( Product
            //var result = ProductsList.Where(P => P.UnitsInStock > 0).Select((P, I) => new
            //{
            //    ID = I,
            //    P.ProductName
            //});

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}



            #endregion

            #endregion

            #region Ordering Operators [Ascending , Descending , Reverse , ThenBy , ThenByDescending]

            #region Get Products Ordered By Price Asc
            ////fluent Syntax
            //var result = ProductsList.OrderBy(P => P.UnitPrice);
            ////Query Syntax
            //result = from P in ProductsList
            //         orderby P.UnitPrice
            //         select P;

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}


            #endregion

            #region Get Products Ordered By Price Desc
            ////fluent Syntax
            //var result = ProductsList.OrderByDescending(P => P.UnitPrice);
            ////Query Syntax
            //result = from P in ProductsList
            //         orderby P.UnitPrice descending
            //         select P;

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Get Products Ordered By Price Asc and Number Of Items In Stock
            ////fluent Syntax
            //var result = ProductsList.OrderBy(P => P.UnitPrice).ThenByDescending(P=>P.UnitsInStock);
            ////Query Syntax
            //result = from P in ProductsList
            //         orderby P.UnitPrice , P.UnitsInStock
            //         select P;

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}



            #endregion

            #region Reverse
            //var result = ProductsList.Where(P => P.UnitsInStock==0).Reverse();

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion



            #endregion

            #region Elements Operator - Immediate Execution [Valid Only With Fluent Syntax]

            #region First , Last , LastOrDefault , FirstOrDefault

            //var Result = ProductsList.First(); // Get First Element At sequence
            //Result = ProductsList.Last(); // Get Last Element At Sequence
            //Console.WriteLine(Result?.ProductName ?? "Not Found");

            //List<Product> TestProduct = new List<Product>();
            //var Result = TestProduct.First(); // InvalidOperationException: Sequence contains no elements
            //Result = TestProduct.Last(); // InvalidOperationException: Sequence contains no elements

            ////First And Last May Throw Exception -> Will Exception If The sequence Is Empty
            //Console.WriteLine(Result);


            //var Result = TestProduct.FirstOrDefault();// Get First Element At sequence
            //Result = TestProduct.LastOrDefault();// Get Last Element At sequence
            //// FirstOrDefault And LastOrDefault => if Sequence Is Empty -> Return Null
            //Console.WriteLine(Result?.ProductName ?? "Not Found");


            //var Result = TestProduct.First(P => P.UnitsInStock == 0); // Get First Element At sequence Match Condition
            //                                                          //Result = TestProduct.Last(P => P.UnitsInStock == 0); // Get Last Element At sequence Match Condition
            //                                                          // First And Last -> If There is no Matching Element -> Thrown Exception

            //var Result = TestProduct.FirstOrDefault(P => P.UnitsInStock == 0);
            //Result = TestProduct.LastOrDefault(P => P.UnitsInStock == 0);
            //// If there is no Matching Element -> Return Default = Null

            //Console.WriteLine(Result?.ProductName ?? "Not Found");



            #endregion

            #region ElementAt , ElementAtOrDefault , Single , SingleOrDefault

            #region Fluent Syntax
            //var Result = ProductsList.ElementAt(77); 
            //// ArgumentOutOfRangeException: Index was out of range

            //var Result = ProductsList.ElementAtOrDefault(77);
            // // If Index Was Out Range => Return Default = null

            //Console.WriteLine(Result?.ProductName ?? "Not Found");


            //var Result = ProducstList.Single(P => P.UnitsInStock == 0);
            ////InvalidOperationException: Sequence contains more than one element
            //// If Sequence Contains Only One Element Match Condition -> Return it
            //// Else Will Throw Exception (Sequence Empty - Sequence Contains More than One Element Match Condt

            //var Result = ProductsList.SingleOrDefault(P => P.UnitPrice == 9999);
            // If Sequence Contains No Element Match condition -> Return Null
            // If Sequence Contains More Than One Element Match condition -> Throw Exception
            // If Sequence Contains Just only One Element Match condition -> Return It

            //Console.WriteLine(Result?.ProductName ?? "Not Found"); 
            #endregion


            #region Hybrid Syntax
            //// Hybrid Syntax = Fluent Syntax + Query Expression
            //// Hybrid Syntax = (Query Syntax).Fluent Syntax

            //var Result = (from P in ProductsList
            //              where P.UnitsInStock == 0
            //              select new
            //              {
            //                  P.ProductID,
            //                  P.ProductName,
            //                  P.UnitsInStock
            //              }).FirstOrDefault();

            //Console.WriteLine(Result); 
            #endregion

            #endregion

            #endregion

            #region Aggregate Operators - Immediate Execution
            #region Count , Max , Min 
            //var Result = ProductsList.Count;//List property

            //var Result = ProductsList.Count(P=>P.UnitsInStock==0);//LINQ Operators
            //Console.WriteLine(Result);

            //var Result = ProductsList.Max(); //At least one object must implement IComparable
            ////Product Must implement IComparable

            //var MaxLength = ProductsList.Max(P => P.ProductName.Length);
            //Console.WriteLine(MaxLength); // no need implement IComparable

            //var Result = (from P in ProductsList
            //              where P.ProductName.Length == MaxLength
            //              select P).FirstOrDefault();

            //Console.WriteLine(Result); 
            #endregion

            //var Result = ProductsList.Sum(P=>P.UnitPrice);//2222.7100
            //Result=ProductsList.Average(P=>P.UnitPrice);//28.86636
            //Console.WriteLine(Result);

            #region Aggregate (+)
            //string[] Names = { "Aya", "Omar", "Amr", "Mohamed" };

            //var Result = Names.Aggregate((Str01, Str02) => $"{Str01} {Str02}");
            //// Str01 =Aya , Str02 = Omar
            //// Str01 = Aya Omar , Str02 = Amr
            //// Str01 = Aya Omar amr , str02 = mohamed
            ////Str01 = Aya Omar amr ,mohamed
            //Console.WriteLine(Result); 
            #endregion


            #endregion

            #region Casting [Conversion] Operators - Immediate Execution

            #region ToList - ToArray - ToDictionary
            //List<Product> Result = ProductsList.Where(P => P.UnitsInStock == 0).ToList(); // Casting To List
            //Product[] Result = ProductsList.Where(P => P.UnitsInStock == 0).ToArray(); // Casting To Array

            //Dictionary<long, Product> Result = ProductsList.Where(P => P.UnitsInStock == 0)
            //                                            .ToDictionary(P => P.ProductID);


            //Dictionary<long, String> Result = ProductsList.Where(P => P.UnitsInStock == 0)
            //                                            .ToDictionary(P=>P.ProductID,P=>P.ProductName);

            //foreach (var item in Result)
            //{
            //    Console.WriteLine($"Key = {item.Key} , Value = {item.Value}");
            //} 
            #endregion

            //HashSet<Product> products = ProductsList.Where(P=>P.UnitsInStock==0).ToHashSet();
            //foreach (var item in products)
            //{
            //    Console.WriteLine(item);
            //}


            //ArrayList Obj = new ArrayList()
            //    {
            //        "Omar" ,
            //        "Ahmed" ,
            //        "Mona" ,
            //        "Aliaa" ,
            //        1 ,
            //        2,
            //        3
            //    };

            //var Result = Obj.OfType<string>();//String or int

            //foreach (var item in Result)
            //{
            //    Console.WriteLine(item);
            //}


            #endregion

            #region Generation Operators - Deferred Execution
            //valid only with fluent Syntax(with static method by call from class Enumerable

            //var Result = Enumerable.Range(0, 100); // 0..99

            //Result = Enumerable.Repeat(2, 100);
            //// Return IEnumerable Of 100 Element each One = 2

            //var Result = Enumerable.Repeat(new Product(), 100);
            //// Return IEnumerable Of 100 Product

            //var arrayProduct = Enumerable.Empty<Product>().ToArray();
            //Product[] Products = new Product[0];
            //// Both Will Generate an Empty Array of Products

            //var List = Enumerable.Empty<Product>().ToList();
            //List<Product> Products02 = new List<Product>();
            //// Both Will Generate An Empty List Of Product

            //foreach (var item in Result)
            //{
            //    Console.Write($"{item} ");
            //}

            #endregion

            #region Set Operators [Union Family] - Deferred Execution
            //var Seq01 = Enumerable.Range(0, 100); // 0...99
            //var Seq02 = Enumerable.Range(50, 100); // 50..149

            //var Result = Seq01.Union(Seq02); // 0..149 -> Remove Duplication
            //var Result = Seq01.Concat(Seq02); // 0..99 + 50..149

            //Result = Result.Distinct(); // Remove Duplication

            //var Result = Seq01.Intersect(Seq02); // 50 .. 99

            //var Result = Seq01.Except(Seq02); // 0..49



            //Console.WriteLine("\n=======================SEQ01=======================");

            //foreach (var item in Seq01)
            //    Console.Write($"{item} , ");

            //Console.WriteLine("\n=======================SEQ02=======================");

            //foreach (var item in Seq02)
            //    Console.Write($"{item} , ");

            //Console.WriteLine("\n=======================Except=======================");

            //foreach (var item in Result)
            //    Console.Write($"{item} , ");

            #endregion

            #region Quantifier Operator - Return boolean

            //var Ruselt = ProductsList.Any();
            ////If Sequence contains at least one Element Will Return True
            //Ruselt = ProductsList.Any(P=>P.UnitsInStock<0);
            //Console.WriteLine(Ruselt);

            // Result = ProductList.Any(P => P.UnitsInStock > 1000); // False


            //var Result = ProductsList.All(P => P.UnitsInStock == 1);
            //// If All Elements in Sequence Match Condition Return True

            //var Seq01 = Enumerable.Range(0, 100); // 0..99
            //var Seq02 = Enumerable.Range(0, 100); // 0..99

            //Result = Seq01.SequenceEqual(Seq02);
            //Console.WriteLine(Result);//True


            #endregion

            #region Zipping Operator - ZIP

            //string[] Names = { "Omar", "Amr", "Ahmed", "May", "Aya" };
            //int[] Numbers = Enumerable.Range(1, 10).ToArray();
            //char[] Chars = { 'A', 'B', 'C', 'D', 'E' };

            //var Result = Names.Zip(Numbers);
            // (Omar, 1)
            // (Amr, 2)
            // (Ahmed, 3)
            // (May, 4)
            // (Aya, 5)

            //var Result = Names.Zip(Numbers, (Name, Number) => new { index = Number, Name });

            //foreach (var item in Result)
            //{
            //    Console.WriteLine(item);
            //}

            //var Result= Names.Zip(Numbers, Chars);
            //foreach (var item in Result)
            //{
            //    Console.WriteLine(item);
            //}



            #endregion

            #region Grouping Operators
            #region Get Products Grouped by Category
            //// Query Syntax
            //var Result = from P in ProductsList
            //             group P by P.Category;

            ////Fluent Syntax
            //var Result = ProductsList.GroupBy(P => P.Category);

            //foreach (var category in Result)
            //{
            //    Console.WriteLine(category.Key); // Name of Category
            //    foreach (var Product in category)
            //    {
            //        Console.WriteLine($"           {Product.ProductName}");
            //    }
            //}

            #endregion

            #region Get Products in Stock Grouped by Category

            //var Resut = from P in ProductsList
            //            where P.UnitsInStock > 0
            //            group P by P.Category;

            //var Ruselt = ProductsList.Where(P => P.UnitsInStock > 0).GroupBy(P => P.Category);

            //foreach (var Category in Ruselt)
            //{

            //    Console.WriteLine(Category.Key);
            //    foreach (var Product in Category)
            //    {
            //        Console.WriteLine($"      {Product.ProductName}");
            //    }
            //}

            #endregion

            #region Get Products in Stock Grouped by Category That Contains More Than 10 Product
            ////fluent
            //var Result = ProductsList.Where(P => P.UnitsInStock > 0)
            //                         .GroupBy(p => p.Category).Where(P=>P.Count()>10);

            ////Qurey Syntax
            //var Result = from P in ProductsList
            //             where P.UnitsInStock>0
            //             group P by P.Category
            //             into Category
            //             where Category.Count()>10
            //             select Category;


            //foreach (var category in Result)
            //{
            //    Console.WriteLine(category.Key); // Name of Category
            //    foreach (var Product in category)
            //    {
            //        Console.WriteLine($"           {Product.ProductName}");
            //    }
            //}


            #endregion

            #region Get Category Name of Products in Stock That Contains More Than 10 Product and Number of Product In Each Category
            //fluent
            //var Result = ProductsList.Where(P => P.UnitsInStock > 0)
            //                         .GroupBy(P => P.Category)
            //                         .Where(C => C.Count() > 10)
            //                         .Select(X => new
            //                         {
            //                             CategoryName = X.Key,
            //                             count = X.Count()
            //                         });

            //var Result = from P in ProductsList
            //             where P.UnitsInStock > 0
            //             group P by P.Category
            //             into Category
            //             where Category.Count() > 10
            //             select new
            //             {
            //                 CategoryName = Category.Key,
            //                 count = Category.Count()
            //             };
            //foreach (var item in Result)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

            #endregion

            #region Partitioning Operators
            //var Result = ProductsList.Take(10);
            //// Take Number of Elements From First Only
            //Result = ProductsList.Where(P => P.UnitsInStock > 0).Take(5);

            //Result = ProductsList.Where(P => P.UnitsInStock > 0).TakeLast(10);
            //// TakeLast => Take Number of Elements From Last Only
            ///

            //var Result = ProductsList.Where(P => P.UnitsInStock == 0).Skip(2);
            // Skip Number of Elements From First And Get Rest Of Elements
            //Result = ProductsList.Where(P => P.UnitsInStock == 0).SkipLast(2);
            //Skip Number of Elements From Last And Get Rest Of Elements

            //var Result = ProductList.Skip(10).Take(10);

            //int[] Numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2 };

            //var Result = Numbers.TakeWhile((Num, I) => Num > I);
            // Take Elements Till Element That do not Match Condition
            //var Result = Numbers.SkipWhile(Num => Num % 3 != 0);
            // Skip Elements Till Element That do not Match Condition

            //foreach (var item in Result)
            //{
            //    Console.WriteLine(item);
            //}



            #endregion

            #region Let and Into [Valid With Query Syntax Only]

            //List<string> Names = new List<string>() { "Omar", "Ali", "Sally", "Mohamed", "Ahmed" };
            //// A , O , U , I , E

            //var Result = from N in Names
            //             select Regex.Replace(N, "[AOUIEaouie]", string.Empty)
            //             into NoVowelNames
            //             where NoVowelNames.Length > 3
            //             select NoVowelNames;
            //// Into => Restart Query With Introducing A New Range Variable : NoVowelNames

            //Result = from N in Names
            //         let NoVowelNames = Regex.Replace(N, "[AOUIEaouie]", string.Empty)
            //         where NoVowelNames.Length>3
            //         select NoVowelNames;

            //// Let => Continue Query With Adding New Range Variable : NoVowelNames

            //foreach (var n in Result)
            //{
            //    Console.WriteLine(n);
            //}

                     #endregion

        }
    }
}
