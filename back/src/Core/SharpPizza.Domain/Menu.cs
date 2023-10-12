public class Menu
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal UnitPrice { get; set; }
    public string? ImageUrl { get; set; }
    public List<Ingredients> Ingredients { get; set; }
    public bool SoldOut { get; set; }
    public int Stock { get; set; }
}
