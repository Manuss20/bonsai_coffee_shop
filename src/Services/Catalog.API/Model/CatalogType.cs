namespace bonsaicoffeeshop.Services.Catalog.API.Model;

/// <summary>
/// Represents a type of catalog item.
/// </summary>
public class CatalogType
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;
}