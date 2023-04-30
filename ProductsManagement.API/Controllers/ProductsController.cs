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
    private readonly IAmazonProductsService _amazonProductsService;

    public ProductsController(IProductsService productsService, IAmazonProductsService amazonProductsService)
    {
        _productsService = productsService;
        _amazonProductsService = amazonProductsService;
    }
    
    [HttpGet("Search")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<ProductSearchResponse>>> Search([FromQuery] string query, [FromQuery] int page)
    {
        try
        {
            var results = await _amazonProductsService.SearchAsync(query, page, "US");
            return Ok(results);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }
    
    [HttpGet("GetDetails")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ProductDetailResponse>> GetProductDetail([FromQuery] string productId)
    {
        try
        {
            var results = await _amazonProductsService.ProductDetailAsync(productId, null);
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