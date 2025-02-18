using Microsoft.AspNetCore.Mvc;
using ShoppingCartStartedKata.Domain;

namespace ShoppingCartStartedKata.Controllers;

[ApiController]
[Route("[controller]")]
public class AvailableProductsController : ControllerBase
{
    [HttpGet]
    public IEnumerable<Product> Get()
    {
        return [new Product(0, "Patata", 0)];
    }
}