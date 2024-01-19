using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Data;
using UserAPI.Models;

namespace UserAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
        private readonly DataContext _context;

		public UserController(DataContext context)
		{
			_context = context;
		}

		[HttpGet("{id}")]
		public  ActionResult<User> GetUser(int id)
		{
			var user = _context.Users.Find(id);
			return new OkObjectResult(user);
		}
		[HttpPost]
		public ActionResult AddUser(User user)
		{
			_context.Users.Add(user);
			_context.SaveChanges();
			return new OkResult();
		}
    }
}
