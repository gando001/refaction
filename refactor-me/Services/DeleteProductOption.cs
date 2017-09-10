using System;
using System.Data.SqlClient;
using refactor_me.Models;

namespace refactor_me.Services
{
    public class DeleteProductOption
    {
        public ProductOption Option { get; private set; }

        public DeleteProductOption(ProductOption option)
        {
            this.Option = option;
        }

		public void Call()
		{
			using (SqlCommand command = new SqlCommand())
			{
				command.CommandText = "delete from productoption where id = '@id'";
                command.Parameters.AddWithValue("@id", Option.Id);

				new RunQuery(command).Execute();
			}
		}
    }
}
