using System;

namespace refactor_me.Models
{
    public class Product
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public decimal Price { get; private set; }

        public decimal DeliveryPrice { get; private set; }

        public Product(Guid id, string name, string description, decimal price, decimal deliveryPrice)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.DeliveryPrice = deliveryPrice;
        }
    }
}