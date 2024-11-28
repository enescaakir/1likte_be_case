using _1likte_be_case.Entities;
using _1likte_be_case.Services;

namespace _1likte_be_case.Tests
{
    public class ShoppingTests
    {
        private readonly ICartService _cartService;

        public ShoppingTests()
        {
            _cartService = new CartService();
        }

        [Fact]
        public void AddToCart_ShouldAddProductToCart()
        {
            var cart = _cartService.CreateCart();
            var product = new Product("Book", 20.00m, "store1");

            _cartService.AddToCart(cart.Id, product, 2);

            Assert.Equal(2, cart.Items.Sum(x => x.Quantity));
            Assert.Equal(40.00m, _cartService.GetTotalPrice(cart.Id));
        }

        [Fact]
        public void RemoveFromCart_ShouldRemoveProduct()
        {
            var cart = _cartService.CreateCart();
            var product = new Product("Book", 20.00m, "store1");
            _cartService.AddToCart(cart.Id, product, 3);

            _cartService.RemoveFromCart(cart.Id, product, 1);

            Assert.Equal(2, cart.Items.Sum(x => x.Quantity));
            Assert.Equal(40.00m, _cartService.GetTotalPrice(cart.Id));
        }

        [Fact]
        public void ClearCart_ShouldRemoveProduct()
        {
            var cart = _cartService.CreateCart();
            var product = new Product("Book", 20.00m, "store1");
            _cartService.AddToCart(cart.Id, product, 3);

            _cartService.RemoveFromCart(cart.Id, product, 3);

            Assert.Empty(cart.Items);
            Assert.Equal(0, _cartService.GetTotalPrice(cart.Id));
        }

        [Fact]
        public void GetCartTotal_ShouldReturnCorrectTotal()
        {
            var cart = _cartService.CreateCart();

            var product1 = new Product("Book", 20.00m, "store1");
            var product2 = new Product("Pen", 5.00m, "store1");
            var product3 = new Product("Rubber", 10.00m, "store2");

            _cartService.AddToCart(cart.Id, product1, 1);
            _cartService.AddToCart(cart.Id, product2, 3);
            _cartService.AddToCart(cart.Id, product3, 1);

            var total = _cartService.GetTotalPrice(cart.Id);

            Assert.Equal(45.00m, total);
        }
    }
}