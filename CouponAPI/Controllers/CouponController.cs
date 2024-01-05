using CouponAPI.Data;
using CouponAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly CouponContext _context;
        public CouponController(CouponContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCoupons()
        {
            var coupons = await _context.Coupons.ToListAsync();
            return Ok(coupons);
        }
        [HttpPost]
        public async Task<IActionResult> AddCoupon(Coupon coupon)
        {
            if (coupon == null)
            {
                return BadRequest();
            }
            await _context.Coupons.AddAsync(coupon);
            await _context.SaveChangesAsync();
            return Ok();

        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCouponbyID(int id)
        {
            var coupon = await _context.Coupons.FindAsync(id);
            if (coupon == null)
            {
                return BadRequest();
            }
            return Ok(coupon);
        }
    }
}
