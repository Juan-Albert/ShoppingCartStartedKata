using Microsoft.AspNetCore.Mvc;
using ShoppingCartStartedKata.Domain;

namespace ShoppingCartStartedKata.Controllers;

[ApiController]
[Route("[controller]")]
public class ShowCartContentController(Cart cart) : ControllerBase
{
    [HttpGet]
    public Cart Get()
    {
        return cart;
    }
}