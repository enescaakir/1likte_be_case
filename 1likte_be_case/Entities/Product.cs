namespace _1likte_be_case.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string StoreId { get; set; }
        public decimal Price { get; set; }

        public Product(string name, decimal price, string storeId)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Product name cannot be empty.");
            if (price <= 0)
                throw new ArgumentException("Product price must be greater than zero.");
            if (string.IsNullOrEmpty(storeId))
                throw new ArgumentException("Product must belong to a store.");

            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            StoreId = storeId;
        }
    }
}
