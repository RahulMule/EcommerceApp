using E_Commerce.Web.Models;
using E_Commerce.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace E_Commerce.Web.Services
{
	public class ProductService : IProductService
	{
		private readonly HttpClient _httpClient;
		public const string BasePath = "/api/Products/";
        public ProductService(HttpClient httpClient)
        {
			_httpClient = httpClient;	
        }
		public async Task<IActionResult> GetAllProduct()
		{
			var response = await _httpClient.GetAsync(BasePath);
			if (response.IsSuccessStatusCode)
			{
				return new OkObjectResult(response.Content);
			}
			return new BadRequestResult();

		}

		public async Task<IActionResult> GetProductAsync(int id)
		{
			string BasePathnew = BasePath + id;
			var response =  await _httpClient.GetAsync(BasePathnew);
			return new OkObjectResult(response.Content);

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

		async Task<IActionResult> IProductService.DeleteProduct(int id)
		{
			string BasePathnew = BasePath + id;
			var response = await _httpClient.DeleteAsync(BasePathnew);
			if (response.IsSuccessStatusCode)
			{
				return new OkResult();
			}
			return new BadRequestResult();
		}

		async Task<IActionResult> IProductService.UpdateProduct(E_Commerce.Web.Models.Product product)
		{
			var response = await _httpClient.PutAsJsonAsync(BasePath,product);
			if (response.IsSuccessStatusCode)
			{
				return new OkResult();
			}
			return new BadRequestResult();
		}
	}
}
