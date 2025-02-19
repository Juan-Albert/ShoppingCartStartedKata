namespace ShoppingCartStartedKata.Domain;

public record Product(int Id, string Name, decimal Price)
{
    public static Product Potato => new(0, "Potato", 1.50m);
    public static Product Carrot => new(1, "Carrot", 0.73m);
    public static Product Tomato => new(2, "Tomato", 2.36m);
};