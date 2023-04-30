using Microsoft.AspNetCore.WebUtilities;
using ProductsManagement.BLL.Helpers;
using ProductsManagement.BLL.ThirdPartyAPIsDTO.Google.Responses;

namespace ProductsManagement.BLL.Services.Abstract;

public interface IGoogleSearchService
{
    Task<IEnumerable<GoogleSearchResult>> SearchByImage(string imgUrl);
}