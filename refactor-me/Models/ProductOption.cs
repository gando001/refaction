using System;

namespace refactor_me.Models
{
    public class ProductOption
    {
        public Guid Id { get; private set; }

        public Guid ProductId { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public ProductOption(Guid id, Guid productId, string name, string description)
        {
            this.Id = id;
            this.ProductId = productId;
            this.Name = name;
            this.Description = description;
        }
    }
}
