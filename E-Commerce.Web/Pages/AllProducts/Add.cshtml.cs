using E_Commerce.Web.Data;
using E_Commerce.Web.Models;
using E_Commerce.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Commerce.Web.Pages.AllProducts
{
	[BindProperties]
	public class AddModel : PageModel
    {
        public E_Commerce.Web.Models.Product Product { get; set; }
        private readonly IProductService _productService;

		public AddModel(IProductService productservice)
		{
            _productService = productservice;
		}

		public void OnGet()
        {
        }
       
       
        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                var response = await _productService.AddProduct(Product);
                if (response != null)
                {
                    return RedirectToPage("Index");
                } 
            }
			
				return NotFound();
		}
    }
}
