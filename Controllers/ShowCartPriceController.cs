using Microsoft.AspNetCore.Mvc;
using ShoppingCartStartedKata.Domain;

namespace ShoppingCartStartedKata.Controllers;

[ApiController]
[Route("[controller]")]
public class ShowCartPriceController(Cart cart) : ControllerBase
{
    [HttpGet]
    public Decimal Get()
    {
        return cart.TotalPrice;
    }
}