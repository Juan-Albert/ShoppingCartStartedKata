using FluentAssertions;
using ShoppingCartStartedKata.Domain;
using Xunit;

namespace Test;

public class CartTest
{
    [Fact]
    public void AddMultipleProducts()
    {
        var cart = new Cart();
        
        cart.AddProduct([Product.Potato, Product.Tomato]);
        
        cart.Products.Should().Contain([Product.Potato, Product.Tomato]);
    }
}