using Microsoft.AspNetCore.Mvc;
using ShoppingCartStartedKata.Domain;

namespace ShoppingCartStartedKata.Controllers;

[ApiController]
[Route("carts")]
public class ShowCartContentController(IList<Cart> carts) : ControllerBase
{
    [HttpGet("{cartId}")]
    public Cart GetCart([FromRoute] string cartId)
    {
        if (!carts.Any(cart => cart.Id == cartId))
            CreateCart(cartId);
        
        return carts.Single(cart => cart.Id == cartId);
    }

    private void CreateCart(string cartId)
    {
        carts.Add(new Cart(cartId));
    }
}