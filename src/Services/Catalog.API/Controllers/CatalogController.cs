using bonsaicoffeeshop.Services.Catalog.API.Model;
using bonsaicoffeeshop.Services.Catalog.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace bonsaicoffeeshop.Services.Catalog.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CatalogController : ControllerBase
{
    private readonly CatalogService _catalogService;

    // Constructor injection of CatalogService
    public CatalogController(CatalogService catalogService) =>
        _catalogService = catalogService;

    /// <summary>
    /// Retrieves all catalog items
    /// </summary>
    [HttpGet]
    public async Task<List<CatalogItem>> Get() =>
        await _catalogService.GetAsync();

    /// <summary>
    /// Retrieves a catalog item by ID
    /// </summary>
    /// <param name="id">The ID of the catalog item to retrieve</param>
    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<CatalogItem>> Get(string id)
    {
        var catalog = await _catalogService.GetAsync(id);

        if (catalog is null)
        {
            return NotFound();
        }

        return catalog;
    }

    /// <summary>
    /// Creates a new catalog item
    /// </summary>
    /// <param name="newCatalogItem">The new catalog item to create</param>
    [HttpPost]
    public async Task<IActionResult> Post(CatalogItem newCatalogItem)
    {
        await _catalogService.CreateAsync(newCatalogItem);

        return CreatedAtAction(nameof(Get), new { id = newCatalogItem.Id }, newCatalogItem);
    }

    /// <summary>
    /// Updates an existing catalog item
    /// </summary>
    /// <param name="id">The ID of the catalog item to update</param>
    /// <param name="updatedCatalogItem">The updated catalog item</param>
    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, CatalogItem updatedCatalogItem)
    {
        var catalog = await _catalogService.GetAsync(id);

        if (catalog is null)
        {
            return NotFound();
        }

        updatedCatalogItem.Id = catalog.Id;

        await _catalogService.UpdateAsync(id, updatedCatalogItem);

        return NoContent();
    }

    /// <summary>
    /// Deletes a catalog item by ID
    /// </summary>
    /// <param name="id">The ID of the catalog item to delete</param>
    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var catalog = await _catalogService.GetAsync(id);

        if (catalog is null)
        {
            return NotFound();
        }

        await _catalogService.RemoveAsync(id);

        return NoContent();
    }

}