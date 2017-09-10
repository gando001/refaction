using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using refactor_me.Models;
using refactor_me.Services;

namespace refactor_me.Queries
{
    public class ProductsQuery
    {
        public List<Product> Items { get; private set; }

        public ProductsQuery()
        {
            this.Items = new List<Product>();
        }

        public IEnumerable<Product> GetAll()
        {
			SqlDataReader reader;
			using (SqlCommand command = new SqlCommand())
			{
				command.CommandText = "select id from product";
				reader = new RunQuery(command).RetrieveRows();
			}

			while (reader.Read())
			{
				Product product = BuildProduct(reader);
				Items.Add(product);
			}

			return Items;
        }

        public IEnumerable<Product> GetProduct(String name)
		{
            SqlDataReader reader;
            using (SqlCommand command = new SqlCommand())
            {
                command.CommandText = "select id from product where lower(name) like '%@name%'";
                command.Parameters.AddWithValue("name", name.ToLower());
                reader = new RunQuery(command).RetrieveRows();
            }

            while (reader.Read())
			{
				Product product = BuildProduct(reader);
				Items.Add(product);
			}

			return Items;
		}

        public Product GetProduct(Guid id)
        {
            SqlDataReader reader;
            using (SqlCommand command = new SqlCommand())
            {
                command.CommandText = "select * from product where id = @id";
                command.Parameters.AddWithValue("id", id);
                reader = new RunQuery(command).RetrieveRows();
            }

            if (!reader.Read())
                return null;

            Product product = BuildProduct(reader);
            return product;
        }

        private Product BuildProduct(SqlDataReader reader)
        {
            Guid id = Guid.Parse(reader["id"].ToString());
			string name = reader["Name"].ToString();
			string description = (DBNull.Value == reader["Description"]) ? null : reader["Description"].ToString();
			decimal price = decimal.Parse(reader["Price"].ToString());
			decimal deliveryPrice = decimal.Parse(reader["DeliveryPrice"].ToString());

			return new Product(id, name, description, price, deliveryPrice);
        }
    }
}
