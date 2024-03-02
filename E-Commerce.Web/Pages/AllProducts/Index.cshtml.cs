using E_Commerce.Web.Data;
using E_Commerce.Web.Models;
using E_Commerce.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

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
            products = (IEnumerable<Models.Product>)_productService.GetAllProduct();
        }
    }
}
