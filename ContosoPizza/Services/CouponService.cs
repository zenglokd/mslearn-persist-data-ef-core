using ContosoPizza.Data;
using ContosoPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Services;

public class CouponService
{
    private readonly PromotionsContext _context;
    public CouponService(PromotionsContext context)
    {
        _context = context;
    }

    public IEnumerable<Coupon> GetAll()
    {
        return _context.Coupons.AsNoTracking().ToList();
    }

    public Coupon? GetById(int id)
    {
        return _context.Coupons.AsNoTracking().SingleOrDefault(c => c.Id == id);
    }

    public Coupon? Create(Coupon newCoupon)
    {
        _context.Coupons.Add(newCoupon);
        _context.SaveChanges();
        return newCoupon;
    }

    public Coupon? Update(int couponId, Coupon updatedCoupon)
    {
        var couponToUpdate = _context.Coupons.Find((long)couponId);
        if (couponToUpdate is not null)
        {
            couponToUpdate.Description = updatedCoupon.Description;
            couponToUpdate.Expiration = updatedCoupon.Expiration;
            _context.SaveChanges();
        }
        return couponToUpdate;
    }

    public void DeleteById(int id)
    {
        var couponToDelete = _context.Coupons.Find((long)id);
        if (couponToDelete is not null)
        {
            _context.Coupons.Remove(couponToDelete);
            _context.SaveChanges();
        }
    }
}