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

        public void AddToCart(Product product, int quantity)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            var existItem = Items.FirstOrDefault(x => x.Product == product);
            if (existItem != null)
                IncreaseQuantity(product, quantity);
            else
            {
                var cartItem = new CartItem(product, quantity);
                Items.Add(cartItem);
            }
            CalculateCartTotal();
        }

        public void RemoveFromCart(Product product, int quantity)
        {
            var existItem = Items.FirstOrDefault(x => x.Product == product);
            if (existItem == null)
                throw new ArgumentNullException(nameof(product));

            DecreaseQuantity(product, quantity);
            CalculateCartTotal();
        }

        public decimal GetTotalPrice()
        {
            return TotalPrice;
        }

        private void IncreaseQuantity(Product product, int quantity)
        {
            Items.FirstOrDefault(x => x.Product == product).Quantity += quantity;
        }

        private void DecreaseQuantity(Product product, int quantity)
        {
            var item = Items.FirstOrDefault(x => x.Product == product);
            var itemIndex = Items.IndexOf(item);

            if (item.Quantity <= quantity)
            {
                Items.RemoveAt(itemIndex);
                return;
            }
            item.Quantity -= quantity;
            Items[itemIndex] = item;
        }

        private void CalculateCartTotal()
        {
            TotalPrice = Items.Sum(x => x.Product.Price * x.Quantity);
        }
    }
}
