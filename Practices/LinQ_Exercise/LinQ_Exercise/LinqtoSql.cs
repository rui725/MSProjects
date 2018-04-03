using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Text;
using System.Threading.Tasks;

namespace LinQ_Exercise
{
    class LinqtoSql
    {
        #region Objects
        [Table(Name = "Distributors")]
        public class Distributor
        {
            private string _Name;
            [Column(IsPrimaryKey = true, Storage = "_Name")]
            public string Name
            {
                get { return this._Name; }
                set { this._Name = value; }
            }

            private string _State;
            [Column(Storage = "_State")]
            public string State
            {
                get { return this._State; }
                set { this._State = value; }
            }

        }

        [Table(Name = "Customers")]
        public class Customer
        {
            private EntitySet<Purchase> _Purchases;
            public Customer()
            {
                this._Purchases = new EntitySet<Purchase>();
            }

            [Association(Storage = "_Purchases", OtherKey = "CLast")]
            public EntitySet<Purchase> Purchases
            {
                get { return this._Purchases; }
                set { this._Purchases.Assign(value); }
            }

            //Properties
            private string _Last;
            [Column(IsPrimaryKey = true, Storage = "_Last")]
            public string Last
            {
                get { return this._Last; }
                set { this._Last = value; }
            }

            private string _First;
            [Column(Storage = "_First")]
            public string First
            {
                get { return this._First; }
                set { this._First = value; }
            }

            private string _State;
            [Column(Storage = "_State")]
            public string State
            {
                get { return this._State; }
                set { this._State = value; }
            }
        }

        [Table(Name = "Purchases")]
        public class Purchase
        {

            private EntityRef<Customer> _Customer;
            public Purchase() { this._Customer = new EntityRef<Customer>(); }

            [Association(Storage = "_Customer", ThisKey = "CLast")]
            public Customer Customer
            {
                get { return this._Customer.Entity; }
                set { this._Customer.Entity = value; }
            }

            //Properties
            private string _ID;
            [Column(IsPrimaryKey = true, Storage = "_ID")]
            public string ID
            {
                get { return this._ID; }
                set { this._ID = value; }
            }

            private string _CLast;
            [Column(Storage = "_CLast")]
            public string CLast
            {
                get { return this._CLast; }
                set { this._CLast = value; }
            }

            private decimal _Price;
            [Column(Storage = "_Price")]
            public decimal Price
            {
                get { return this._Price; }
                set { this._Price = value; }
            }

            private string _Item;
            [Column(Storage = "_Item")]
            public string Item
            {
                get { return this._Item; }
                set { this._Item = value; }
            }
        }

        #endregion
        //change to main
        static void Test3()
        //static void Main(string[] Args)
        {
            string cn_string = "Data Source=RUI-PC\\SQLDB;Initial Catalog=linq_db;User ID=sa;Password=test";
            DataContext db = null;
            try
            {
               db = new DataContext(cn_string);

                //get datas from tables
                Table<Customer> customers = db.GetTable<Customer>();
                Table<Distributor> distributors = db.GetTable<Distributor>();
                Table<Purchase> purchases = db.GetTable<Purchase>();
                //query string
                var query =
                    from c in customers
                    from p in c.Purchases
                    where c.State == "OR" && p.Price > 500
                    select c;
                foreach (var item in query)
                {
                    //updating records
                    item.First = "-ok";
                    //displaying records
                    Console.WriteLine(item.Last + " "+ item.State);
                }
                db.SubmitChanges();
                
            }catch(Exception e)
            {

                Console.WriteLine(e);
            }
            
            Console.ReadKey();
        }
    }
}
