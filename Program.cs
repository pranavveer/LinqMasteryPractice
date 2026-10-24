using LinqMastery.Data;
using System.Linq;

namespace LinqMastery;

public class Program
{
     public static void Main()
     {
         Console.WriteLine("LINQ Mastery Practice Project");
         Console.WriteLine("Uncomment one exercise method at a time in Main().");

          Exercise01_Filtering();
          Exercise02_Projection();
          Exercise03_SelectMany();
          Exercise04_Sorting();
          Exercise05_ElementOperators();
          Exercise06_Aggregation();
          Exercise07_AnyAll();
          Exercise08_Grouping();
          Exercise09_SetOperations();
          Exercise10_InnerJoin();
          Exercise11_LeftJoin();
          Exercise12_GroupJoin();
          Exercise13_Partitioning();
          Exercise14_QuantifiersAndMembership();
          Exercise15_StringAndNumericQueries();
          Exercise16_NestedQueries();
          Exercise17_CombinedQueries();
          Exercise18_DictionaryAndLookup();
          Exercise19_JoinOrdersAndCustomers();
          Exercise20_Reports();
     }

     // RULE: For every task, implement both styles where supported.
     // Use these labels to keep your work organised:
     // METHOD SYNTAX PRACTICE
     // QUERY SYNTAX PRACTICE

     static void Exercise01_Filtering()
     {
         var products = StoreData.Products;

         // Task 1: Find products priced above 5,000.
         // METHOD SYNTAX PRACTICE
         // TODO: products.Where(...)
         var productsAbove5000Method = products.Where(p => p.Price > 5000);
         foreach (var x in productsAbove5000Method)
         {
             Console.WriteLine(x.ProductName);
         }
         // QUERY SYNTAX PRACTICE
         // TODO: from p in products where ... select p
         var productsAbove5000Query = from p in products
                                      where p.Price > 5000
                                      select p;
         // Task 2: Find Electronics products that are in stock.
         // METHOD SYNTAX PRACTICE
         // TODO: Where with &&
         var electronicsInStockMeth=products.Where(p => p.Category == "Electronics" && p.Stock > 0);

         // QUERY SYNTAX PRACTICE
         // TODO: where with &&
         var electronicsInstockQuery = from p in products
                                       where p.Category == "Electronics" && p.Stock > 0
                                       select p;

         // Task 3: Find products priced between 1,000 and 20,000.
         // METHOD SYNTAX PRACTICE
         // TODO
         var productInRageMethod = products.Where(p => p.Price > 1000 && p.Price < 20000);

         // QUERY SYNTAX PRACTICE
         // TODO
         var productInRangeQuery = from p in products
                                   where p.Price < 20000 && p.Price > 1000
                                   select p;

         // Task 4: Find products whose names contain "Office".
         // METHOD SYNTAX PRACTICE
         // TODO: Contains()
         var productsOfficeMeth=products.Where(p=>p.ProductName.Contains("Office"));
         // QUERY SYNTAX PRACTICE
         // TODO
         var productsOfficeQuery = from p in products
                                   where p.ProductName.Contains("Office")
                                   select p;
     }

     static void Exercise02_Projection()
     {
         var products = StoreData.Products;

         // Task 1: Select only product names.
         // METHOD SYNTAX PRACTICE
         // TODO: Select(...)
         var productnamesMethod = products.Select(p => p.ProductName);

         // QUERY SYNTAX PRACTICE
         // TODO: select p.ProductName
         var productNameQuery = from p in products
                                select p.ProductName;

         // Task 2: Return ProductName and Price using an anonymous type.
         // METHOD SYNTAX PRACTICE
         // TODO: Select(p => new { ... })
         var productNamePriceMethod = products.Select(p => new
         {
             p.ProductName,
             p.Price
         });

         // QUERY SYNTAX PRACTICE
         // TODO: select new { ... }
         var productNamePriceQuery = from p in products
                                     select new
                                     {
                                         p.ProductName,
                                         p.Price
                                     };

         // Task 3: Return ProductName, Price, and PriceWithTax (18%).
         // METHOD SYNTAX PRACTICE
         // TODO
         var ProductNamePricePriceWithTaxMethod = products.Select(p =>new 
         {
            Name= p.ProductName,
            Price= p.Price,
             Tax=p.Price+(p.Price*0.18m)
         }
         );

         // QUERY SYNTAX PRACTICE
         // TODO
         var ProductNamePricePriceWithTaxQuery = from p in products
                                                 select new
                                                 {
                                                     Name = p.ProductName,
                                                     Price = p.Price,
                                                     Tax = p.Price + (p.Price * 0.18m)

                                                 };
      }

     static void Exercise03_SelectMany()
     {
         var batches = StoreData.TrainingBatches;
         var products = StoreData.Products;
         // Task 1: Flatten all training batches into one sequence.
         // METHOD SYNTAX PRACTICE
         // TODO: SelectMany()
         var allBatchesMethods = batches.SelectMany(t => t);

         // QUERY SYNTAX PRACTICE
         // TODO: use two from clauses
         var allBatchesQuery = from t in batches
                               from b in batches
                               select b;

         // Task 2: Get every product tag as one flat sequence.
         // METHOD SYNTAX PRACTICE
         // TODO
         var allTagsMethods = products.Select( p =>p);

         // QUERY SYNTAX PRACTICE
         // TODO
     }

     static void Exercise04_Sorting()
     {
         var products = StoreData.Products;

         // Task 1: Sort by price ascending.
         // METHOD SYNTAX PRACTICE
         // TODO: OrderBy()
         var ascendingPrice = products.OrderBy(p => p.Price);

         // QUERY SYNTAX PRACTICE
         // TODO: orderby

         // Task 2: Sort by price descending.
         // METHOD SYNTAX PRACTICE
         // TODO: OrderByDescending()
         var descendingPrice = products.OrderByDescending(p => p.Price);

         // QUERY SYNTAX PRACTICE
         // TODO: orderby ... descending

         // Task 3: Sort by Category ascending, then Price descending.
         // METHOD SYNTAX PRACTICE
         // TODO: OrderBy().ThenByDescending()
         var ascendingDescendingPrice = products.OrderBy(p => p.Price).ThenByDescending(p => p.Price);

         // QUERY SYNTAX PRACTICE
         // TODO
     }

     static void Exercise05_ElementOperators()
     {
         var products = StoreData.Products;

         // Task 1: Find the first product priced above 10,000.
         // METHOD SYNTAX PRACTICE
         // TODO: First()
         var firstProduct = products.First(p=>p.Price>10000);

         // QUERY SYNTAX PRACTICE
         // TODO: query + First()

         // Task 2: Search for ProductId 999 safely.
         // METHOD SYNTAX PRACTICE
         // TODO: FirstOrDefault()
         var productId999 = products.FirstOrDefault(p=>p.ProductId==999);

         // QUERY SYNTAX PRACTICE
         // TODO: query + FirstOrDefault()

         // Task 3: Find ProductId 3 using Single().
         // METHOD SYNTAX PRACTICE
         // TODO: Single()
         var productId3 = products.Single(p=>p.ProductId==3);

         // QUERY SYNTAX PRACTICE
         // TODO: query + Single()
     }

     static void Exercise06_Aggregation()
     {
         var products = StoreData.Products;

         // Task 1: Count all products.
         // METHOD SYNTAX PRACTICE
         // TODO: Count()
         var allproductsCount = products.Count();

         // QUERY SYNTAX PRACTICE
         // TODO: query + Count()

         // Task 2: Calculate total stock.
         // METHOD SYNTAX PRACTICE
         // TODO: Sum()
         var totalStock =products.Sum(p=>p.Stock);

         // QUERY SYNTAX PRACTICE
         // TODO: query + Sum()

         // Task 3: Find ,minimum  and maximum price.
         // METHOD SYNTAX PRACTICE
         // TODO
         var average = products.Average(p => p.Price);
         var minimum = products.Min(p =>p.Price);
         var maximum = products.Max(p => p.Price);



         // QUERY SYNTAX PRACTICE
         // TODO

         // Task 4: Calculate total inventory value (Price * Stock).
         // METHOD SYNTAX PRACTICE
         // TODO
         var toatlInventoryVal = products.Sum(p => p.Price * p.Stock);

         // QUERY SYNTAX PRACTICE
         // TODO
     }

     static void Exercise07_AnyAll()
     {
         var products = StoreData.Products;

         // Task 1: Check whether any product costs more than 50,000.
         // METHOD SYNTAX PRACTICE
         // TODO: Any()
         var productsCostsMore50000 = products.Any(p=>p.Price > 50000);

         // QUERY SYNTAX PRACTICE
         // TODO: query + Any()

         // Task 2: Check whether all products have non-negative stock.
         // METHOD SYNTAX PRACTICE
         // TODO: All()
         var productsnonnegative = products.All(p=>p.Stock>0m);

         // QUERY SYNTAX PRACTICE
         // TODO: query + All()
     }

     static void Exercise08_Grouping()
     {
         var products = StoreData.Products;

         // Task 1: Group products by Category.
         // METHOD SYNTAX PRACTICE
         // TODO: GroupBy()
         var productsbyCategory = products.GroupBy(p=>p.Category);

         // QUERY SYNTAX PRACTICE
         // TODO: group ... by ...

         // Task 2: For each category, calculate product count,
         // total stock, and average price.
         // METHOD SYNTAX PRACTICE
         // TODO: GroupBy + Select
         var groupbySelect = products.GroupBy(p => p.Category)
         .Select(g => new
         {
             Category = g.Key,
             ProductCount = g.Count(),
             TotalStock=g.Sum(p=>p.Stock),
             Avrg=g.Average(p=>p.Price)
         });


         // QUERY SYNTAX PRACTICE
         // TODO: group ... by ... into ...
     }

     static void Exercise09_SetOperations()
     {
         var a = StoreData.ListA;
         var b = StoreData.ListB;

         // Task 1: Remove duplicates.
         // METHOD SYNTAX PRACTICE
         // TODO: Distinct()
         var noduplicatesInA = a.Distinct();
         var noduplicatesInBb = b.Distinct();

         // QUERY SYNTAX PRACTICE
         // TODO: query + Distinct()

         // Task 2: Find union, intersection and A-only values.
         // METHOD SYNTAX PRACTICE
         // TODO: Union(), Intersect(), Except()
         var union = a.Union(b);
         var intersec = a.Intersect(b);
         var except = a.Except(b);

         // QUERY SYNTAX PRACTICE
         // TODO: query results + set operators
     }

     static void Exercise10_InnerJoin()
     {
         var employees = StoreData.Employees;
         var departments = StoreData.Departments;

         // Task: Display EmployeeName and DepartmentName for matching records.
         // METHOD SYNTAX PRACTICE
         // TODO: Join()
         var displayEmpandDeptName = employees.Join(departments,
             e => e.DepartmentId,
             d => d.DepartmentId,
             (e, d) => new
             {
                 EmployeeName = e.EmployeeName,
                 DepartmentName = d.DepartmentName
             }

             );

         // QUERY SYNTAX PRACTICE
         // TODO: join ... on ... equals ...
     }

     static void Exercise11_LeftJoin()
     {
         var employees = StoreData.Employees;
         var departments = StoreData.Departments;

         // Task: Return every employee, displaying "Unassigned" if
         // no matching department exists.
         // METHOD SYNTAX PRACTICE
         // TODO: LeftJoin() on .NET 10, or GroupJoin + SelectMany

         // QUERY SYNTAX PRACTICE
         // TODO: join ... into ... then DefaultIfEmpty()
     }

     static void Exercise12_GroupJoin()
     {
         var employees = StoreData.Employees;
         var departments = StoreData.Departments;

         // Task: Return each department with its employee count.
         // METHOD SYNTAX PRACTICE
         // TODO: GroupJoin()

         // QUERY SYNTAX PRACTICE
         // TODO: join ... into ...
     }

     static void Exercise13_Partitioning()
     {
         var products = StoreData.Products.OrderBy(p => p.ProductId);

         // Task 1: Get first three products.
         // METHOD SYNTAX PRACTICE
         // TODO: Take(3)

         // QUERY SYNTAX PRACTICE
         // TODO: query + Take(3)

         // Task 2: Skip first three products.
         // METHOD SYNTAX PRACTICE
         // TODO: Skip(3)

         // QUERY SYNTAX PRACTICE
         // TODO: query + Skip(3)
     }

     static void Exercise14_QuantifiersAndMembership()
     {
         List<int> requestedIds = new() { 1, 3, 5 };

         // Task: Find products whose IDs occur in requestedIds.
         // METHOD SYNTAX PRACTICE
         // TODO: Where + Contains

         // QUERY SYNTAX PRACTICE
         // TODO: where + Contains
     }

     static void Exercise15_StringAndNumericQueries()
     {
         var products = StoreData.Products;

         // Task 1: Find names starting with "O".
         // METHOD SYNTAX PRACTICE
         // TODO: StartsWith()

         // QUERY SYNTAX PRACTICE
         // TODO

         // Task 2: Find products with even ProductIds.
         // METHOD SYNTAX PRACTICE
         // TODO: modulo operator %

         // QUERY SYNTAX PRACTICE
         // TODO
     }

     static void Exercise16_NestedQueries()
     {
         var products = StoreData.Products;
         var orders = StoreData.Orders;

         // Task 1: Find products priced above average.
         // METHOD SYNTAX PRACTICE
         // TODO: Average + Where

         // QUERY SYNTAX PRACTICE
         // TODO

         // Task 2: Find customers with at least one order.
         // METHOD SYNTAX PRACTICE
         // TODO: Where + Any

         // QUERY SYNTAX PRACTICE
         // TODO
     }

     static void Exercise17_CombinedQueries()
     {
         var products = StoreData.Products;

         // Task: Find in-stock Electronics products, sort by descending
         // price, and return only product names.
         // METHOD SYNTAX PRACTICE
         // TODO: Where + OrderByDescending + Select

         // QUERY SYNTAX PRACTICE
         // TODO: from + where + orderby + select
     }

     static void Exercise18_DictionaryAndLookup()
     {
         var products = StoreData.Products;

         // Task 1: Create a dictionary keyed by ProductId.
         // METHOD SYNTAX PRACTICE
         // TODO: ToDictionary()

         // QUERY SYNTAX PRACTICE
         // TODO: query + ToDictionary()

         // Task 2: Create a lookup by Category.
         // METHOD SYNTAX PRACTICE
         // TODO: ToLookup()

         // QUERY SYNTAX PRACTICE
         // TODO: query + ToLookup()
     }

     static void Exercise19_JoinOrdersAndCustomers()
     {
         var orders = StoreData.Orders;
         var customers = StoreData.Customers;

         // Task: Show OrderId, CustomerName, OrderDate and Status.
         // METHOD SYNTAX PRACTICE
         // TODO: Join + Select

         // QUERY SYNTAX PRACTICE
         // TODO: join + select
     }

     static void Exercise20_Reports()
     {
         var products = StoreData.Products;
         var orders = StoreData.Orders;

         // Task 1: Count orders by Status.
         // METHOD SYNTAX PRACTICE
         // TODO: GroupBy + Count

         // QUERY SYNTAX PRACTICE
         // TODO: group by + Count

         // Task 2: Create a category report with product count,
         // average price, total stock and inventory value.
         // METHOD SYNTAX PRACTICE
         // TODO

         // QUERY SYNTAX PRACTICE
         // TODO
     }
 }
 /*  class Eventexample
    {
    public static void Main(String[] args)
    {
        Eventexample example = new Eventexample();
        example.Run();
    }
        
        public void Display(string msg)
        {
            Console.WriteLine(msg);
        }
        public void Run()
    { 
             Predicate<string>a = Display();
            a.("hello");
        }
    }
*/