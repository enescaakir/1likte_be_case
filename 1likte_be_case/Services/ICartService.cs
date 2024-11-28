using _1likte_be_case.Entities;

namespace _1likte_be_case.Services
{
    public interface ICartService
    {
        Cart CreateCart();
        public Cart GetCart(Guid cartId);
        public void AddToCart(Guid cartId, Product product, int quantity);
        public void RemoveFromCart(Guid cartId, Product product, int quantity);
        public decimal GetTotalPrice(Guid cartId);
    }
}
