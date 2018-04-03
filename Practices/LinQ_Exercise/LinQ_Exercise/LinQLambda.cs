using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ_Exercise
{
    class LinQLambda
    {
        #region Class Definitions
        public class Customer
        {
            public string First { get; set; }
            public string Last { get; set; }
            public string State { get; set; }
            public double Price { get; set; }
            public string[] Purchases { get; set; }
        }

        public class Distributor
        {
            public string Name { get; set; }
            public string State { get; set; }
        }

        public class CustDist
        {
            public string custName { get; set; }
            public string distName { get; set; }
        }

        public class CustDistGroup
        {
            public string custName { get; set; }
            public IEnumerable<string> distName { get; set; }
        }
        #endregion

        #region Create data sources

        static List<Customer> customers = new List<Customer>
        {
            new Customer {First = "Cailin", Last = "Alford", State = "GA", Price = 930.00, Purchases = new string[] {"Panel 625", "Panel 200"}},
            new Customer {First = "Theodore", Last = "Brock", State = "AR", Price = 2100.00, Purchases = new string[] {"12V Li"}},
            new Customer {First = "Jerry", Last = "Gill", State = "MI", Price = 585.80, Purchases = new string[] {"Bulb 23W", "Panel 625"}},
            new Customer {First = "Owens", Last = "Howell", State = "GA", Price = 512.00, Purchases = new string[] {"Panel 200", "Panel 180"}},
            new Customer {First = "Adena", Last = "Jenkins", State = "OR", Price = 2267.80, Purchases = new string[] {"Bulb 23W", "12V Li", "Panel 180"}},
            new Customer {First = "Medge", Last = "Ratliff", State = "GA", Price = 1034.00, Purchases = new string[] {"Panel 625"}},
            new Customer {First = "Sydney", Last = "Bartlett", State = "OR", Price = 2105.00, Purchases = new string[] {"12V Li", "AA NiMH"}},
            new Customer {First = "Malik", Last = "Faulkner", State = "MI", Price = 167.80, Purchases = new string[] {"Bulb 23W", "Panel 180"}},
            new Customer {First = "Serena", Last = "Malone", State = "GA", Price = 512.00, Purchases = new string[] {"Panel 180", "Panel 200"}},
            new Customer {First = "Hadley", Last = "Sosa", State = "OR", Price = 590.20, Purchases = new string[] {"Panel 625", "Bulb 23W", "Bulb 9W"}},
            new Customer {First = "Nash", Last = "Vasquez", State = "OR", Price = 10.20, Purchases = new string[] {"Bulb 23W", "Bulb 9W"}},
            new Customer {First = "Joshua", Last = "Delaney", State = "WA", Price = 350.00, Purchases = new string[] {"Panel 200"}}
        };

        static List<Distributor> distributors = new List<Distributor>
        {
            new Distributor {Name = "Edgepulse", State = "UT"},
            new Distributor {Name = "Jabbersphere", State = "GA"},
            new Distributor {Name = "Quaxo", State = "FL"},
            new Distributor {Name = "Yakijo", State = "OR"},
            new Distributor {Name = "Scaboo", State = "GA"},
            new Distributor {Name = "Innojam", State = "WA"},
            new Distributor {Name = "Edgetag", State = "WA"},
            new Distributor {Name = "Leexo", State = "HI"},
            new Distributor {Name = "Abata", State = "OR"},
            new Distributor {Name = "Vidoo", State = "TX"}
        };

        static double[] exchange = { 0.89, 0.65, 120.29 };
        static double[] ExchangedPrices = {827.70, 604.50, 111869.70,
                                        1869.00, 1,365.00, 252609.00,
                                        521.36, 380.77, 70465.88,
                                        455.68, 332.80, 61588.48,
                                        2018.34, 1474.07, 272793.66,
                                        920.26, 672.10, 124379.86,
                                        1873.45, 1368.25, 253210.45,
                                        149.34, 109.07, 20184.66,
                                        455.68, 332.80, 61588.48,
                                        525.28, 383.63, 70995.16,
                                        9.08, 6.63, 1226.96,
                                        311.50, 227.50, 42101.50};

        static string[] Purchases = {  "Panel 625", "Panel 200",
                                    "12V Li",
                                    "Bulb 23W", "Panel 625",
                                    "Panel 200", "Panel 180",
                                    "Bulb 23W", "12V Li", "Panel 180",
                                    "Panel 625",
                                    "12V Li", "AA NiMH",
                                    "Bulb 23W", "Panel 180",
                                    "Panel 180", "Panel 200",
                                    "Panel 625", "Bulb 23W", "Bulb 9W",
                                    "Bulb 23W", "Bulb 9W",
                                    "Panel 200"
                                 };

        #endregion

        static void Test2(string[] Args) { 
        //static void Main(string []Args) {
            //Query comprehension Syntax
            // pros you can use SelectMany, Join, and GroupJoin 
            // cons not able to use Distinct, Take/Skip,TakeWhile,SkipWhile, Set Operators, and Aggregations
            IEnumerable<Customer> query_comp_syn =
                from c in customers
                select c;
            //Lambda syntax
            // pros can use Distinct, Take/Skip, TakeWhile, SkipWhile, set Operators, and Aggregations
            // cons not able to use SelectMany, Join and GroupJoin
            IEnumerable<Customer> lambda_comp_yn =
                customers.Where(c => c.State == "OR");

            foreach (Customer item in lambda_comp_yn)
            {
                Console.WriteLine("{0} {1}",item.Last, item.State);
            }

            //Indexing
            Console.WriteLine("\n\nIndexing using Lambda");
            IEnumerable<double> index_lambda = ExchangedPrices
                .Where((x, index) => index % 3 == 0);

            foreach (double item in index_lambda)
            {
                Console.WriteLine(item);
            };

            //Distinct
            Console.WriteLine("\n\nDistinct using Lambda");
            IEnumerable<string> distinct_lambda = Purchases
                .Distinct();
            foreach (string item in distinct_lambda)
            {
                Console.WriteLine(item);
            }

            //Take lets you search the sequence from 0 index up until n .Take(n);
            Console.WriteLine("\n\nTake using Lambda");
            IEnumerable<string> take_lambda = Purchases
               .Take(3);
            foreach (string item in take_lambda)
            {
                Console.WriteLine(item);
            }
            //Skip lets you search the sequence from n up to the end Skip(n);
            // you can also make use of combining or chaining commands like .Skip(n).Take(n); and so on
            Console.WriteLine("\n\nSkip using Lambda");
            IEnumerable<string> skip_lambda = Purchases
              .Skip(3);
            foreach (string item in skip_lambda)
            {
                Console.WriteLine(item);
            }

            //TakeWhile lets you get the sequence based from a filter;
            Console.WriteLine("\n\nTakeWhile using Lambda");
            IEnumerable<string> takewhile_lambda = Purchases
               .TakeWhile(p => p.Contains("Panel")); // gets the first occurance for Panel inside the sequence
            foreach (string item in takewhile_lambda)
            {
                Console.WriteLine(item);
            }

            //Skip lets you skip the sequence based from a filter;
            Console.WriteLine("\n\nSkipWhile using Lambda");
            IEnumerable<string> skipwhile_lambda = Purchases
               .SkipWhile(p => p.Contains("Panel")); // skips the first occurance sequence for Panel inside the sequence
            foreach (string item in skipwhile_lambda)
            {
                Console.WriteLine(item);
            }

            //orderby queries
            Console.WriteLine("\n\nOrderBy using Lambda");
            IEnumerable<Customer> order_lambda =
                customers.OrderBy(x => x.State);

            foreach (Customer item in order_lambda)
            {
                Console.WriteLine("{0} {1}", item.Last, item.State);
            }

            //thenby queries
            // orders state and then orders the last name aswell
            Console.WriteLine("\n\nThenBy using Lambda");
            IOrderedEnumerable<Customer> thenby_lambda =
                customers.OrderBy(x => x.State).ThenBy(n => n.Last);
            foreach (Customer item in thenby_lambda)
            {
                Console.WriteLine("{0} {1}", item.Last, item.State);
            }

            //Group queries
            Console.WriteLine("\n\nGroupBy using Lambda");
            IEnumerable<IGrouping<string, Customer>> groupby_lambda =
                customers.GroupBy(x => x.State);
            foreach (IGrouping<string, Customer> item in groupby_lambda)
            {
                Console.WriteLine(item.Key);
                foreach (var i in item)
                {
                    Console.WriteLine(" {0} {1} ", i.Last, i.State);
                }
            }
            //Another Example
            IEnumerable<IGrouping<bool, Customer>> groupby_lambda_bool =
                customers.GroupBy(x => x.Price >= 1000);
            foreach (IGrouping<bool, Customer> item in groupby_lambda_bool)
            {
                Console.WriteLine(item.Key);
                foreach (var i in item)
                {
                    Console.WriteLine(" {0} {1}: {2:C}", i.Last, i.State, i.Price);
                }
            }

            //Join Query Lambdas
            Console.WriteLine("\n\nJoin using Lambda");
            var join_lambda =
                customers.Join(
                    distributors,
                    // On in Join Clause
                    c => c.State,
                    d => d.State,
                    (c, d) => new { Name = c.Last, distName = d.Name }
                    );
            foreach (var item in join_lambda)
            {
                Console.WriteLine("{0} - {1}", item.Name, item.distName);
            }

            //GroupJoin Query Lambdas
            Console.WriteLine("\n\nGroupJoin using Lambda");
            var group_join_lambda =
                customers.GroupJoin(
                    distributors,
                    // On in Join Clause
                    c => c.State,
                    d => d.State,
                    (c, d) => new { Name = c.Last, distName = d.Select(x => x.Name) }
                    );
            foreach (var item in group_join_lambda)
            {
                Console.WriteLine("Customer: "+item.Name);
                foreach (var i in item.distName)
                {
                    Console.WriteLine("\tDistributor "+i);
                }
            }

            //SELECTS in Lambda
            Console.WriteLine("\n\nSelect using Lambda");
            IEnumerable<double> select_lambda =
                customers.Select(x => x.Price * .89);
            foreach (double item in select_lambda)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n\nSelectMany using Lambda");
            IEnumerable<double> select_many_lambda =
                customers.SelectMany(c => exchange, (c, e) => c.Price * e);
            foreach (double item in select_many_lambda)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n\nSelectMany hiearchy using Lambda");
            IEnumerable<string> select_many_hei_lamda =
                customers.SelectMany(c => c.Purchases);
            foreach (string item in select_many_hei_lamda)
            {
                Console.WriteLine(item);
            }

            //Chain Query
            Console.WriteLine("\n\nChain using Lambda");
            IEnumerable<string> chain_lambda =
                customers.Where(c => c.State == "OR")
                .OrderBy(c => c.Price)
                .Select(c => c.Last);
            foreach (string item in chain_lambda)
            {
                Console.WriteLine(item);
            }

            // into complex
            Console.WriteLine("\n\nInto complex");
            //sample problem
            /*
             * from c in customers
             * select c.Price * 0.89 What if you want to only get processed data which is greater than 500 it is impossible
             * where c.Price > 500
             * orderby c.Last;
             * 
             * use into to solve this
             */
            var into_complex =
                from c in customers
                select new { euro = c.Price * .89, cus = c }
                into inEuros
                where inEuros.euro > 500
                orderby inEuros.cus.Last
                select new { inEuros.cus.Last, inEuros.euro};

            foreach (var item in into_complex)
            {
                Console.WriteLine(item.euro + " " + item.Last);
            }
            /*
             * Lambda version of this query
             * customers.Select( c => {c.Price * .89; return c;})
             * .Where(c => c.Price > 500)
             * OrderBy(c => c.Last);
             */

            Console.WriteLine("\n\nLet complex");
            //let new range or local variable that can be used in a query
            //using the into_complex example
            var let_complex =
                from c in customers
                let euro = c.Price * .89
                where euro > 500
                orderby c.Last
                select new { euro = euro, Name = c.Last };

            foreach (var item in let_complex)
            {
                Console.WriteLine("{0} {1}", item.Name, item.euro);
            }

            //another use for let
            // let uses mostly for SQL Server
            Console.WriteLine("\n\nLet complex example 2");
            var let_complex2 =
                from c in customers
                let euro = c.Price * .89
                from p in c.Purchases
                let ke = "KE on" + p
                select new { ke = ke, euro = euro, c.Last, c.State };

            foreach (var item in let_complex2)
            {
                Console.WriteLine("{0} spent {1} on {2}", item.Last, item.euro, item.ke);
            }

            Console.ReadKey();
        }
    }

}
