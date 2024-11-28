using _1likte_be_case.Entities;

namespace _1likte_be_case.Services
{
    public class CartService : ICartService
    {
        private readonly List<Cart> _carts = new();

        public Cart CreateCart()
        {
            var cart = new Cart();
            _carts.Add(cart);
            return cart;
        }
        public void AddToCart(Guid cartId, Product product, int quantity)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            var cart = _carts.FirstOrDefault(x => x.Id == cartId);
            var cartIndex = _carts.IndexOf(cart);

            var existItem = cart.Items.FirstOrDefault(x => x.Product == product);
            if (existItem != null)
                IncreaseQuantity(cart, product, quantity);
            else
            {
                var cartItem = new CartItem(product, quantity);
                cart.Items.Add(cartItem);
            }
            CalculateCartTotal(cart);
            _carts[cartIndex] = cart;
        }

        public Cart GetCart(Guid cartId)
        {
            return _carts.FirstOrDefault(x => x.Id == cartId);
        }

        public void RemoveFromCart(Guid cartId, Product product, int quantity)
        {
            var cart = _carts.FirstOrDefault(x => x.Id == cartId);
            var cartIndex = _carts.IndexOf(cart);

            var existItem = cart.Items.FirstOrDefault(x => x.Product == product);
            var existItemIndex = cart.Items.IndexOf(existItem);
            if (existItem == null)
                throw new ArgumentNullException(nameof(product));

            DecreaseQuantity(cart, product, quantity);
            CalculateCartTotal(cart);

            _carts[cartIndex] = cart;
        }

        public decimal GetTotalPrice(Guid cartId)
        {
            var cart = _carts.FirstOrDefault(x => x.Id == cartId);
            return cart.TotalPrice;
        }

        private void IncreaseQuantity(Cart cart, Product product, int quantity)
        {
            cart.Items.FirstOrDefault(x => x.Product == product).Quantity += quantity;
        }

        private void DecreaseQuantity(Cart cart, Product product, int quantity)
        {
            cart.Items.FirstOrDefault(x => x.Product == product).Quantity -= quantity;
        }

        private void CalculateCartTotal(Cart cart)
        {
            cart.TotalPrice = cart.Items.Sum(x => x.Product.Price * x.Quantity);
        }
    }
}
