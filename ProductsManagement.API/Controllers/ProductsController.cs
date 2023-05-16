using Microsoft.AspNetCore.Mvc;
using ProductsManagement.BLL.DTO.Requests;
using ProductsManagement.BLL.DTO.Responses;
using ProductsManagement.BLL.Services.Abstract;

namespace ProductsManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductsService _productsService;

    public ProductsController(IProductsService productsService)
    {
        _productsService = productsService;
    }
    
    [HttpGet("Search")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<ProductSearchResponse>>> Search([FromQuery] string query, [FromQuery] int page, string? region = "US")
    {
        try
        {
            var results = await _productsService.ProductSearch(query, page, region);
            return Ok(results);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }
    
    [HttpGet("GetDetail")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ProductDetailResponse>> GetProductDetail(string productId, int marketplaceId)
    {
        try
        {
            var results = await _productsService.GetProductDetail(productId, marketplaceId);
            return Ok(results);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }
    
    // [HttpGet("SearchByImage")]
    // [ProducesResponseType(StatusCodes.Status200OK)]
    // [ProducesResponseType(StatusCodes.Status403Forbidden)]
    // [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    // public async Task<ActionResult<IEnumerable<ProductSearchResponse>>> SearchByImage([FromQuery] string imageUrl)
    // {
    //     try
    //     {
    //         var results = await _aliexpressProductsService.SearchByImage(imageUrl, "priceAsc", null, null);
    //         return Ok(results);
    //     }
    //     catch (Exception e)
    //     {
    //         return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
    //     }
    // }
    
    [HttpGet("GetOffers")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<ProductOfferResponse>>> SearchByImage([FromQuery] ProductOffersRequest request)
    {
        try
        {
            var results = await _productsService.GetProductOffers(request);
            return Ok(results);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }
}