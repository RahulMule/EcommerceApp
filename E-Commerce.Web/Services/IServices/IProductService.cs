﻿using E_Commerce.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Web.Services.IServices
{
	public interface IProductService
	{
		Task<IActionResult> AddProduct(Product product);
		Task<IActionResult> DeleteProduct(int id);
		Task<IActionResult> UpdateProduct(Product product);
		Task<IActionResult> GetAllProduct();
		Product GetProductAsync(int id);
	}
}