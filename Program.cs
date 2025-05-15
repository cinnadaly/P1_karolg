using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P1_karolg.Models;

namespace P1_karolg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //empty object
            //  Category c = new Category(1);
            //  Console.WriteLine(c.CategoryName);
            //  Console.WriteLine(c.Description);
            //  Console.Read();

            /*var list =Category.GetAll();
            foreach (var category in list)
            {
                Console.WriteLine(category.CategoryId);
                Console.WriteLine(category.CategoryName);
                Console.WriteLine(category.Description);

            }
            Console.Read();*/
            var list = Supplier.GetAll();
            foreach (var supplier in list) 
            {
                Console.WriteLine("ID: "+supplier.SupplierID);
                Console.WriteLine("Company: "+supplier.CompanyName);
                Console.WriteLine("Name: "+supplier.ContactName);
                Console.WriteLine("Title: "+supplier.contactTitle);
                Console.WriteLine("Address: "+supplier.Address);
                Console.WriteLine("City: "+supplier.City);
                Console.WriteLine("Country: "+supplier.Country);
                Console.WriteLine("Phone: "+supplier.Phone);
                Console.WriteLine("-----------------------------");
            }

        }
    }
}
