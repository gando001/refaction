using System;
using System.Data.SqlClient;
using refactor_me.Models;

namespace refactor_me.Services
{
    public class CreateProduct
    {
        public Product Product { get; private set; }

        public CreateProduct(Product product)
        {
            this.Product = product;
        }

        public void Call()
        {
			using (SqlCommand command = new SqlCommand())
			{
                command.CommandText = "insert into product (id, name, description, price, deliveryprice) values ('@id', '@name', '@description', @price, @deliveryPrice)";
				command.Parameters.AddWithValue("@id", Product.Id);
                command.Parameters.AddWithValue("@name", Product.Name);
                command.Parameters.AddWithValue("@description", Product.Description);
                command.Parameters.AddWithValue("@price", Product.Price);
                command.Parameters.AddWithValue("@deliveryprice", Product.DeliveryPrice);

                new RunQuery(command).Execute();
			}
        }
    }
}
