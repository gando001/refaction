using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using refactor_me.Models;
using refactor_me.Services;

namespace refactor_me.Queries
{
    public class ProductOptionsQuery
    {
        public List<ProductOption> Items { get; private set; }

		public ProductOptionsQuery()
		{
			this.Items = new List<ProductOption>();
		}

		public IEnumerable<ProductOption> GetAll(Guid productId)
		{
            SqlDataReader reader;
            using (SqlCommand command = new SqlCommand())
            {
                command.CommandText = "select id from productoption where productid = @productId";
                command.Parameters.AddWithValue("productId", productId);
                reader = new RunQuery(command).RetrieveRows();
            }

            while (reader.Read())
			{
                ProductOption productOption = buildProductOption(reader);
				Items.Add(productOption);
			}

			return Items;
		}

		public ProductOption GetOption(Guid id)
		{
            SqlDataReader reader;
            using (SqlCommand command = new SqlCommand())
            {
                command.CommandText = "select * from productoption where id = @id";
                command.Parameters.AddWithValue("id", id);
                reader = new RunQuery(command).RetrieveRows();
            }

            if (!reader.Read())
				return null;

            ProductOption option = buildProductOption(reader);
			return option;
		}

		private ProductOption buildProductOption(SqlDataReader reader)
		{
			Guid id = Guid.Parse(reader["id"].ToString());
            Guid productId = Guid.Parse(reader["ProductId"].ToString());
            string name = reader["Name"].ToString();
			string description = (DBNull.Value == reader["Description"]) ? null : reader["Description"].ToString();

            return new ProductOption(id, productId, name, description);
		}
    }
}
