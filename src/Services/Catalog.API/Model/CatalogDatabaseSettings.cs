namespace bonsaicoffeeshop.Services.Catalog.API.Model;

// This file contains the CatalogDatabaseSettings class which represents the settings for the catalog database connection.

public class CatalogDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string CatalogCollectionName { get; set; } = null!;
}