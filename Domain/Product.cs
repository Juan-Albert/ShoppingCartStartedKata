namespace ShoppingCartStartedKata.Domain;

public record Product(int Id, string Name, decimal Price)
{
    public static Product Potato() => new(0, "Potato", 1.50m);
};