using _1likte_be_case.Entities;
using _1likte_be_case.Services;

namespace _1likte_be_case
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cartService = new CartService();

            var cart1 = cartService.CreateCart();
            var product1 = new Product("Kitap", 50m, "store1");
            cartService.AddToCart(cart1.Id, product1, 5);

            var product2 = new Product("Oyun Konsolu", 2000m, "store2");
            cartService.AddToCart(cart1.Id, product2, 1);

            var cart2 = cartService.CreateCart();
            var product3 = new Product("Televizyon", 1105.00m, "store2");
            cartService.AddToCart(cart2.Id, product3, 100);

        }
    }
}
