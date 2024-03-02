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
	 public async Task<IEnumerable<Product>> GetAllProduct()
        {
            var response = await _httpClient.GetAsync(BasePath);
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                var responseContent = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON string into a list of Product objects
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(responseContent);

                return products;
            }
            else
            {
                // Handle unsuccessful response
                // You can return null or an empty list based on your error handling strategy
                return null;
            }
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
