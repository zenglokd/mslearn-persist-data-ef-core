using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class CouponController : ControllerBase
{
    CouponService _service;

    public CouponController(CouponService service)
    {
        _service = service;
    }

    [HttpGet]
    public IEnumerable<Coupon> GetAll()
    {
        return _service.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<Coupon> GetById(int id)
    {
        var coupon = _service.GetById(id);

        if (coupon is not null)
        {
            return coupon;
        }
        else
        {
            return NotFound();
        }
    }


    [HttpPost]
    public IActionResult Create(Coupon newCoupon)
    {
        var coupon = _service.Create(newCoupon);
        return CreatedAtAction(nameof(GetById), new { id = coupon!.Id }, coupon);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Coupon updatedCoupon)
    {
        var couponToUpdate = _service.GetById(id);
        if (couponToUpdate is not null)
        {
            couponToUpdate = _service.Update(id, updatedCoupon);
            return Ok(couponToUpdate);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var coupon = _service.GetById(id);

        if (coupon is not null)
        {
            _service.DeleteById(id);
            return Ok();
        }
        else
        {
            return NotFound();
        }
    }
}