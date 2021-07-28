using ORMDapperExercise1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;

namespace BestBuyBestPractices
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;
        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public void CreateProduct(string newProductName, double newProductPrice, int newCategoryID)
        {
            _connection.Execute("INSERT INTO PRODUCTS (Name, Price, CategoryID) VALUES (@productName, @productPrice, @productCategoryID);", 
                new { productName = newProductName, productPrice = newProductPrice, productCategoryID = newCategoryID });
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM ProductS;");
        }
        
    }
}
