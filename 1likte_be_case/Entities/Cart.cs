namespace _1likte_be_case.Entities
{
    public class Cart
    {
        public Guid Id { get; set; }
        public List<CartItem> Items { get; set; }
        public decimal TotalPrice { get; set; }

        public Cart()
        {
            Id = Guid.NewGuid();
            Items = new List<CartItem>();
        }
    }
}
