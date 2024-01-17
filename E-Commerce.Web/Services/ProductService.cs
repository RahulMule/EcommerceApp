using E_Commerce.Web.Models;
using E_Commerce.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Web.Services
{
	public class ProductService : IProductService
	{
		private readonly HttpClient _httpClient;
		public const string BasePath = "/api/Products";
        public ProductService(HttpClient httpClient)
        {
			_httpClient = httpClient;	
        }
        public async Task<IActionResult> AddProduct(Product product)
		{
			var response = await _httpClient.PostAsJsonAsync(BasePath, product);
			if (response.IsSuccessStatusCode)
			{
				return new OkResult();
			}
			return new BadRequestResult();
			
		}
	}
}
