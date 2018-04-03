using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ_Exercise
{
    class Program
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
        #endregion
        static string[] currency = { "1", "2", "3" };
        //TEST if not being used or MAIN if being used
        static void TEST(string[] args)
        {
            // IEnumerable <Type> varname this can be used to Iterate through the data source
            IEnumerable<Customer> s =
                // Structure query
                // data source
                from c in customers
                // filter where
                where c.State == "GA"
                // select statement or group clause
                select c;
            
            foreach (var item in s)
            {
                Console.WriteLine("{0} {1} {2}", item.First, item.Last, item.State);
            }

            Console.WriteLine("\n\nReturning New Type");
            //Creating alias or returning results as new type
            var query =
                from c in customers
                from p in c.Purchases
                // created new return type using new keyword and assigning holders for the result
                select new { Name = c.First + " " + c.Last, Purchases = p };
            
            foreach(var q in query)
            {
                Console.WriteLine("{0} , {1}", q.Name, q.Purchases);
            }

            

            Console.WriteLine("\n\nType Relationship\n Source to Range Variable");
            // Type Relationship
            //Source < - > Range Variable  Source is Customer Class so the select should return type Customer
            IEnumerable<Customer> s_to_r =
              from c in customers
              select c;
            foreach (Customer item in s_to_r)
            {
                Console.WriteLine("{0} {1} {2}", item.First, item.Last, item.State);
            }
            Console.WriteLine("\n\nQuery Variable to Selected Elements");
            //Query variable < - > Selected Elements returns selected elements (type string because c.Last is string)
            IEnumerable<String> q_to_s =
               from c in customers
               select c.Last;
            foreach (string item in q_to_s)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n\nIteration variable to Iteration Variable");
            //Iteration variable < - > Iteration variable uses anonymous type lets the compiler to define datatype
            // this is good to use to not create classes
            var i_to_i =
                from c in customers
                where c.State == "OR"
                select c.Last;
            foreach (string item in i_to_i)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n\nWhere Clause");
            var whereclause =
                from c in customers
                where c.State == "OR" && c.Price > 1000
                select c;
            foreach (Customer item in whereclause)
            {
                Console.WriteLine("{0} {1} {2} {3}", item.First, item.Last, item.State, item.Price);
            }


            Console.WriteLine("\n\nORDERBY Clause");
            var orderby_clause =
                from c in customers
                orderby c.State descending
                select c;
            foreach (Customer item in orderby_clause)
            {
                Console.WriteLine("{0} {1} {2} {3}", item.First, item.Last, item.State, item.Price);
            }

            Console.WriteLine("\n\nGroupBy Clause\nSample IGROUP");
            //GROUPING QUERY
            // IGROUPING<KeyType, ElementType>
            // Key type is the return type of the result of the group by clause
            // element is the result type of the query
            IEnumerable<IGrouping<String, Customer>> group_clause =
                from c in customers
                orderby c.State
                group c by c.State;

            foreach(IGrouping<String, Customer> c in group_clause){
                Console.WriteLine(c.Key);
                foreach (Customer g in c)
                {
                    Console.WriteLine(" {0} {1}", g.First,g.Last);
                }
            }
            Console.WriteLine("\n\nGroupBy Clause\nSample IGROUP bool");
            IEnumerable<IGrouping<bool,Customer>> group_bool_clause =
              from c in customers
              orderby c.First
              group c by c.Price > 1000;

            foreach (IGrouping<bool, Customer> c in group_bool_clause)
            {
                Console.WriteLine(c.Key);
                foreach (Customer g in c)
                {
                   Console.WriteLine(" {0} {1} {2}", g.First, g.Last, g.Price);
                }
            }

            Console.WriteLine("\n\nJoin Clause");
            var join_clause =
                from c in customers
                join d in distributors on c.State equals d.State
                select new { Name = c.Last, distName = d.Name};

            foreach (var item in join_clause)
            {
                Console.WriteLine("{0} {1}", item.Name, item.distName);
            }

            Console.WriteLine("\n\nGroupJoin Clause\nGrouping with no Group Key");
            IEnumerable<IEnumerable<Distributor>> group_join_clause =
               from c in customers
               join d in distributors on c.State equals d.State into
               matches
               select matches;
            foreach (IEnumerable<Distributor> item in group_join_clause)
            {
                Console.WriteLine("Group:");
                foreach (Distributor d in item)
                {
                    // matche better two group by the last name of the customers
                    Console.WriteLine(" " + d.Name);
                }
            }
            Console.WriteLine("\n\nGroupJoin Clause\nGrouping with with Group Key");
            var group_join_clause_key =
                from c in customers
                join d in distributors on c.State equals d.State into
                matches
                select new {
                    custName = c.Last,
                    Name = matches.Select(dist => dist.Name)
                };
            foreach (var item in group_join_clause_key)
            {
                Console.WriteLine(item.custName);
                foreach (var d in item.Name)
                {
                    // matche better two group by the last name of the customers
                    Console.WriteLine(" " + d);
                }
            }
            
            Console.WriteLine("\n\nSelect Clause");
            var select_clause =
                from c in customers
                from e in exchange
                orderby c.Last
                select new { Name = c.Last, Price = c.Price * e };
            foreach (var item in select_clause)
            {
                Console.WriteLine("{0}", item.Name);
                Console.WriteLine("{0}",item.Price);
                int index = 0;
              //  foreach (var i in item.Price.ToString())
               // {
                //    if (index % 3 == 0) { index = 0; }
                //    Console.WriteLine("Currency "+currency[index++]+" "+i);
                    
              //}
            }

            

            Console.ReadKey();
        }
    }
}
