using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using ShoppingCartStartedKata;
using Xunit;
using static ShoppingCartStartedKata.Domain.Product;

namespace Test;

public class ShoppingCartTest
{
    [Fact]
    public async Task ShowAvailableProducts()
    {
        var webFactory = new WebApplicationFactory<WebDummy>();
        var client = webFactory.CreateClient();

        var result = await client.GetAsync("/availableProducts");

        result.IsSuccessStatusCode.Should().BeTrue();
        var content = await result.Content.ReadAsStringAsync();
        content.Should().Contain(Potato.Name);
    }

    [Fact]
    public async Task ShowCartContent()
    {
        var webFactory = new WebApplicationFactory<WebDummy>();
        var client = webFactory.CreateClient();

        var result = await client.GetAsync("/carts/0");

        result.IsSuccessStatusCode.Should().BeTrue();
        var content = await result.Content.ReadAsStringAsync();
        content.Should().Contain("0");
    }

    [Fact]
    public async Task ShowProducts()
    {
        var webFactory = new WebApplicationFactory<WebDummy>();
        var client = webFactory.CreateClient();
        var potato = Potato;
        
        var postResult = await client.PostAsJsonAsync("/addProduct", potato);
        
        postResult.IsSuccessStatusCode.Should().BeTrue();
        
        var getResult = await client.GetAsync("/showCartContent");
        
        getResult.IsSuccessStatusCode.Should().BeTrue();
        var content = await getResult.Content.ReadAsStringAsync();
        content.Should().Contain(Potato.Name);
    }

    [Fact]
    public async Task ShowTotalPrice()
    {
        var webFactory = new WebApplicationFactory<WebDummy>();
        var client = webFactory.CreateClient();

        await client.PostAsJsonAsync("/addProduct", Potato);
        await client.PostAsJsonAsync("/addProduct", Carrot);
        await client.PostAsJsonAsync("/addProduct", Tomato);
        
        var result = await client.GetAsync("/showCartPrice");

        result.IsSuccessStatusCode.Should().BeTrue();
        var content = await result.Content.ReadAsStringAsync();
        content.Should().Be((Potato.Price + Carrot.Price + Tomato.Price).ToString());
    }

}
