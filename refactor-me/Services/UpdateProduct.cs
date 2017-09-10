using System;
using System.Data.SqlClient;
using refactor_me.Models;

namespace refactor_me.Services
{
    public class UpdateProduct
    {
        public Guid Id { get; private set; }
        public Product Product { get; private set; }

        public UpdateProduct(Guid id, Product product)
        {
            this.Id = id;
            this.Product = product;
        }

        public void Call()
        {
			using (SqlCommand command = new SqlCommand())
			{
				command.CommandText = "update product set name = '@name', description = '@description', price = @price, deliveryprice = @deliveryPrice where id = '@id'";
				command.Parameters.AddWithValue("@name", Product.Name);
				command.Parameters.AddWithValue("@description", Product.Description);
				command.Parameters.AddWithValue("@price", Product.Price);
				command.Parameters.AddWithValue("@deliveryPrice", Product.DeliveryPrice);
                command.Parameters.AddWithValue("@id", Id);

				new RunQuery(command).Execute();
			}
        }
    }
}
