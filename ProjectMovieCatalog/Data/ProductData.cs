using ProjectMovieCatalog.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMovieCatalog.Data
{
    internal class ProductData
    {
        public List<Product> GetAll()
        {
            var productList = new List<Product>();
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT * FROM product", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var product = new Product(
                            reader.GetInt32(0),     
                            reader.GetString(1),
                            reader.GetInt32(2),
                            reader.GetString(3),
                            reader.GetString(4),
                            reader.GetString(5),
                            reader.GetString(6),
                            reader.GetString(7),
                            reader.GetString(8)
                            );
                        productList.Add(product);
                    }
                }
                connection.Close();
            }
            return productList;
        }

        public Product Get(int id)
        {
            Product product = null;
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT * FROM product WHERE Id=@id", connection);
                command.Parameters.AddWithValue("id", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        product = new Product(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetInt32(2),
                            reader.GetString(3),
                            reader.GetString(4),
                            reader.GetString(5),
                            reader.GetString(6),
                            reader.GetString(7),
                            reader.GetString(8)
                            );
                    }
                }
                connection.Close();
            }
            return product;
        }

        public void Add(Product product)
        {
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("INSERT INTO product VALUES(@title, @genre, @description, @producer, @director, @views, @mainactor, @mostviewsinonemonth)", connection);
                command.Parameters.AddWithValue("name", product.Title);
                command.Parameters.AddWithValue("genre", product.Genre);
                command.Parameters.AddWithValue("description", product.Description);
                command.Parameters.AddWithValue("producer", product.Producer);
                command.Parameters.AddWithValue("director", product.Director);
                command.Parameters.AddWithValue("views", product.Views);
                command.Parameters.AddWithValue("mainactor", product.MainActor);
                command.Parameters.AddWithValue("mostviewsinonemonth", product.MostViewsInOneMonth);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public void Update(Product product)
        {
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("UPDATE product SET Title = @title, Genre = @genre, Description = @description, Producer = @producer, Director = @director, Views = @views, MainActor = @mainactor, MostViewsInOneMonth = @mostviewsinonemonth", connection);
                command.Parameters.AddWithValue("id", product.Id);
                command.Parameters.AddWithValue("name", product.Title);
                command.Parameters.AddWithValue("genre", product.Genre);
                command.Parameters.AddWithValue("description", product.Description);
                command.Parameters.AddWithValue("producer", product.Producer);
                command.Parameters.AddWithValue("director", product.Director);
                command.Parameters.AddWithValue("views", product.Views);
                command.Parameters.AddWithValue("mainactor", product.MainActor);
                command.Parameters.AddWithValue("mostviewsinonemonth", product.MostViewsInOneMonth);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public void Delete(int id)
        {
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("DELETE product WHERE Id=@id", connection);
                command.Parameters.AddWithValue("id", id);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
