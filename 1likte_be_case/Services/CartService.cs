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
            var cart = _carts.FirstOrDefault(x => x.Id == cartId);
            if (cart is null) throw new ArgumentNullException(nameof(cart));
            _carts.Remove(cart);

            cart.AddToCart(product, quantity);
            _carts.Add(cart);
        }

        public Cart GetCart(Guid cartId)
        {
            return _carts.FirstOrDefault(x => x.Id == cartId);
        }

        public void RemoveFromCart(Guid cartId, Product product, int quantity)
        {
            var cart = _carts.FirstOrDefault(x => x.Id == cartId);
            if (cart is null) throw new ArgumentNullException(nameof(cart));
            _carts.Remove(cart);

            cart.RemoveFromCart(product, quantity);
            if (cart.Items.Any())
                _carts.Add(cart);
        }

        public decimal GetTotalPrice(Guid cartId)
        {
            var cart = _carts.FirstOrDefault(x => x.Id == cartId);
            if (cart is null)
                return 0;
            return cart.TotalPrice;
        }


    }
}
