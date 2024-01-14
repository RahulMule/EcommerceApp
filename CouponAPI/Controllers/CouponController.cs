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
            Coupon cpn = _context.Coupons.FirstOrDefault<Coupon>(u => u.CouponName.ToLower() == coupon.CouponName.ToLower());
            if (cpn == null)
            {
                await _context.Coupons.AddAsync(coupon);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest("Coupon Already exists");
            }

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

        [HttpGet]
        [Route("/CouponName/{name}")]
        public async Task<IActionResult> GetCouponbyName(string name)
        {
            Coupon? coupon =  _context.Coupons.FirstOrDefault<Coupon>(u => u.CouponName == name);
            if (coupon == null)
            {
                return BadRequest();
            }
            return Ok(coupon);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCouponbyID(int id)
        {
            Coupon? coupon = await _context.Coupons.FindAsync(id);
            if(coupon == null)
            {
                return BadRequest();
            }
            _context.Coupons.Remove(coupon);
            await _context.SaveChangesAsync();
            return Ok();

        }

    }
}
