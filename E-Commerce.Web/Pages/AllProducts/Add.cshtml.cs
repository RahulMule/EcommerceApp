using E_Commerce.Web.Data;
using E_Commerce.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Commerce.Web.Pages.AllProducts
{
	[BindProperties]
	public class AddModel : PageModel
    {
        public E_Commerce.Web.Models.Product Product { get; set; }
        private readonly ProductContext _context;

		public AddModel(ProductContext context)
		{
			_context = context;
		}

		public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        { 
            if( ModelState.IsValid)
            {
                _context.Products.Add(Product);
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
                return NotFound();
        }
    }
}
