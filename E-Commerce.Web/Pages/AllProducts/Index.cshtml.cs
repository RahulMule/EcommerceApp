using E_Commerce.Web.Data;
using E_Commerce.Web.Models;
using E_Commerce.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Commerce.Web.Pages.Product
{
    public class IndexModel : PageModel
    {
		private readonly IProductService _productService;
		
		public IEnumerable<E_Commerce.Web.Models.Product> products { get; set; }

        public IndexModel(IProductService productService)
        {
			_productService = productService;
        }

        public void OnGet()
        {
           var result = await _productService.GetAllProduct();
            if (result is OkObjectResult okResult)
            {
                Products = (IEnumerable<Product>)okResult.Value;
            }
            else
            {
                // Handle other cases like BadRequest, NotFound, etc.
                Products = new List<Product>(); // Set products to an empty list or handle the error accordingly
            }
          
        }	
	}
}
