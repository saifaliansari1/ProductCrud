using Dapper;
using ProductCrud.Models;
using System.Data;
using System.Data.SqlClient;

namespace ProductCrud.Repository
{
    public class ProductRepo : IProductRepo
    {

        private IDbConnection _dbConnection;

        public ProductRepo(IConfiguration configuration)
        {
            this._dbConnection = new SqlConnection(configuration.GetConnectionString("DbConnection"));
        }


        public Product Add(Product product)
        {
            product.CreatedAt = DateTime.Now;

            var sql = @"INSERT INTO Products(Name, Description, CreatedAt) VALUES(@Name, @Description, @CreatedAt);
                        SELECT CAST(SCOPE_IDENTITY() AS int);";

            //int id = _dbConnection.Query<int>(sql, new { @Name = product.Name, @Description = product.Description, @CreatedAt = product.CreatedAt }).Single();
            int id = _dbConnection.Query<int>(sql, product).Single();

            product.Id = id;
            return product;
        }

        public Product Update(Product product)
        {
            var sql = @"UPDATE Products SET Name = @Name, Description = @Description WHERE Id=@Id";
            _dbConnection.Execute(sql, new { @Id = product.Id, @Name = product.Name, @Description = product.Description });
            return product;
        }

        public void Remove(int id)
        {
            var sql = "DELETE FROM Products WHERE Id = @Id";
            _dbConnection.Execute(sql, new { @Id = id });
        }

        public Product Find(int id)
        {
            var sql = "SELECT * FROM Products WHERE Id=@Id";
            return _dbConnection.Query<Product>(sql, new { @Id = id }).Single();
        }

        public IEnumerable<Product> GetAll()
        {
            var sql = "SELECT * FROM Products";
            return _dbConnection.Query<Product>(sql);
        }


    }
}
