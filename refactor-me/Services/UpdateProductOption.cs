using System;
using System.Data.SqlClient;
using refactor_me.Models;

namespace refactor_me.Services
{
    public class UpdateProductOption
    {
		public Guid Id { get; private set; }
		public ProductOption Option { get; private set; }

        public UpdateProductOption(Guid id, ProductOption option)
        {
            this.Id = id;
            this.Option = option;
        }

		public void Call()
		{
			using (SqlCommand command = new SqlCommand())
			{
				command.CommandText = "update productoption set name = '@name', description = '@description' where id = '@id'";
                command.Parameters.AddWithValue("@name", Option.Name);
				command.Parameters.AddWithValue("@description", Option.Description);
				command.Parameters.AddWithValue("@id", Id);

				new RunQuery(command).Execute();
			}
		}
    }
}
