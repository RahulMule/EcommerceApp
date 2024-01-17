using E_Commerce.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Web.Services.IServices
{
	public interface IProductService
	{
		Task<IActionResult> AddProduct(Product product);
	}
}
