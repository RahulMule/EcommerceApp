using E_Commerce.Web.Data;
using E_Commerce.Web.Models;
using E_Commerce.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Commerce.Web.Pages.Product
{
    public class EditModel : PageModel
    {
		private readonly IProductService _productService;
		public E_Commerce.Web.Models.Product Product { get; set; }

		public EditModel(IProductService productService)
		{ 
			_productService = productService;
		}

		public void OnGet(int Id)
        {
			Product = _productService.GetProductAsync(Id);
        }
        public async Task<IActionResult> OnPost(E_Commerce.Web.Models.Product product)
        {
           var response = await _productService.UpdateProduct(product);
			if(response != null)
			{
				return RedirectToPage("Index");
			}
            return RedirectToPage("Index");
        }
		

	}
}
