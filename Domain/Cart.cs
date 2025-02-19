namespace ShoppingCartStartedKata.Domain;

public class Cart
{
    private readonly List<Product> products = new();
    
    public IReadOnlyList<Product> Products => products;
    
    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public override string ToString()
    {
        return products.Count == 0 ? "{}" : string.Join(", ", products);
    }
}