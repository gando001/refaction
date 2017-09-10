using System;
using System.Data.SqlClient;
using refactor_me.Models;
using refactor_me.Queries;

namespace refactor_me.Services
{
    public class DeleteProduct
    {
        public Product Product { get; private set; }

        public DeleteProduct(Product product)
        {
            this.Product = product;
        }

        public void Call()
        {
			ProductOptionsQuery query = new ProductOptionsQuery();
            foreach (ProductOption option in query.GetAll(Product.Id))
            {
                new DeleteProductOption(option).Call();
            }
			
			using (SqlCommand command = new SqlCommand())
			{
				command.CommandText = "delete from product where id = '@id'";
				command.Parameters.AddWithValue("@id", Product.Id);

				new RunQuery(command).Execute();
			}
        }
    }
}
