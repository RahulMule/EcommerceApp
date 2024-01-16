using E_Commerce.Web.Data;
using E_Commerce.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Commerce.Web.Pages.Product
{
    public class IndexModel : PageModel
    {
        private readonly ProductContext _context;
		
		public IEnumerable<E_Commerce.Web.Models.Product> products { get; set; }

        public IndexModel(ProductContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            products = _context.Products;
          
        }
		
		public IActionResult OnPostDelete(int id)
		{
			var product = _context.Products.Find(id);

			if (product == null)
			{
				return NotFound();
			}

			_context.Products.Remove(product);
			_context.SaveChanges();

			return RedirectToPage();
		}
	}
}
