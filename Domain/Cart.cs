namespace ShoppingCartStartedKata.Domain;

public class Cart
{
    private readonly List<Product> products = new();
    
    public IReadOnlyList<Product> Products => products;
    public Decimal TotalPrice => products.Sum(x => x.Price);

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public override string ToString()
    {
        return products.Count == 0 ? "{}" : string.Join(", ", products);
    }
}