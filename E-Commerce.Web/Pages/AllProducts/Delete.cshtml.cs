using E_Commerce.Web.Data;
using E_Commerce.Web.Models;
using E_Commerce.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Commerce.Web.Pages.AllProducts
{
    public class DeleteModel : PageModel
    {
		private readonly IProductService _productService;


		public DeleteModel(IProductService productservice)
		{
			_productService = productservice;
		}

		public E_Commerce.Web.Models.Product Product { get; set; }
		public void OnGet(int Id)
        {
			Product = _productService.GetProductAsync(Id);
        }
		public async Task<IActionResult> OnPost(E_Commerce.Web.Models.Product product)
		{
			var response = _productService.DeleteProduct(product.Id);
			if(response != null)
			{
				return RedirectToPage("Index");
			}
			return RedirectToPage("Index");
		}
    }
}
