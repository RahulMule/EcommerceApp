using E_Commerce.Web.Data;
using E_Commerce.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Commerce.Web.Pages.Product
{
    public class EditModel : PageModel
    {
        private readonly ProductContext _context;
		public E_Commerce.Web.Models.Product Product { get; set; }

		public EditModel(ProductContext context)
		{
			_context = context;
		}

		public void OnGet(int Id)
        {
             Product = _context.Products.Find(Id);
        }
        public async Task<IActionResult> OnPost(E_Commerce.Web.Models.Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
		public async Task<IActionResult> OnDelete(E_Commerce.Web.Models.Product product)
		{
			_context.Products.Remove(product);
			await _context.SaveChangesAsync();
			return RedirectToPage("Index");
		}




	}
}
