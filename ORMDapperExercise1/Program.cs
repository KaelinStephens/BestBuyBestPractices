using System;
using System.Data;
using System.IO;
using BestBuyBestPractices;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace ORMDapperExercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            //var repo = new DapperDepartmentRepository(connString);  //Without Dapper
            IDbConnection conn = new MySqlConnection(connString);
            var repo = new DapperDepartmentRepository(conn);
            var productRepo = new DapperProductRepository(conn);
            Console.WriteLine("Type a new Department name");
            var newDepartment = Console.ReadLine();
            repo.InsertDepartment(newDepartment);
            var departments = repo.GetAllDepartments();
            foreach (var dept in departments)
            {
                Console.WriteLine(dept.Name);
            }

            Console.WriteLine();
            Console.WriteLine("*************************************************************");
            Console.WriteLine();
            Console.WriteLine("Type a new Product name");
            var newProduct = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("How much does it cost?");
            var newProductPrice = double.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("What is its CategoryID?");
            var newCategoryID = int.Parse(Console.ReadLine());
            productRepo.CreateProduct(newProduct, newProductPrice, newCategoryID);
            var products = productRepo.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Name}  {product.Price}   {product.CategoryID}");
            }
            //     Bonus:
            // Create the UpdateProduct method in the DapperProductRepository class and implement in Program.cs
            //
            //     Extra Bonus:
            // Create the DeleteProduct method
            //
            // HINT: you will need to delete records from the Sales table and the Reviews table where that Product may be referenced.You can do this all in the DeleteProduct method you are creating
        }
    }
}
