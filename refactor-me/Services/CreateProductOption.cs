using System;
using System.Data.SqlClient;
using refactor_me.Models;

namespace refactor_me.Services
{
    public class CreateProductOption
    {
        public Guid ProductId { get; private set; }
        public ProductOption Option { get; private set; }

        public CreateProductOption(Guid productId, ProductOption option)
        {
            this.ProductId = productId;
            this.Option = option;
        }

        public void Call()
        {
			using (SqlCommand command = new SqlCommand())
			{
				command.CommandText = "insert into productoption (id, productid, name, description) values ('@id', '@productid', '@name', '@description')";
				command.Parameters.AddWithValue("@id", Option.Id);
                command.Parameters.AddWithValue("@productid", ProductId);
				command.Parameters.AddWithValue("@name", Option.Name);
				command.Parameters.AddWithValue("@description", Option.Description);

				new RunQuery(command).Execute();
			}
        }
    }
}
