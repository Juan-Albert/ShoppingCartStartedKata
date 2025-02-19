using Microsoft.AspNetCore.Mvc;
using ShoppingCartStartedKata.Domain;

namespace ShoppingCartStartedKata.Controllers;

[ApiController]
[Route("[controller]")]
public class AddProductController(Cart cart) : ControllerBase
{
    [HttpPost]
    public IResult Post(Product toAdd)
    {
        cart.AddProduct(toAdd);
        return Results.Created("Product", toAdd);
    }
}