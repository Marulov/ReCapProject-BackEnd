using Core.DataAccess.EntityFramework;
using Core.Utilities.Result.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentCarContext>, IRentalDal
    {
        public List<CarRentalDetailDto> GetCarDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (RentCarContext context = new RentCarContext())
            {
            var result= from r in filter == null ? context.Rentals : context.Rentals.Where(filter)
                       join c in context.Cars
                       on r.CarId equals c.CarId
                       join cu in context.Customers
                       on r.CustomerId equals cu.CustomerId
                       join u in context.Users
                       on cu.UserId equals u.UserId
                       select new CarRentalDetailDto
                       {
                           RentalId = r.RentalId,
                           CarName = c.CarName,
                           UserName = u.FirstName + " " + u.LastName,
                           CustomerName = cu.CustomerName,
                           RentDate = r.RentDate,
                           ReturnDate = r.ReturnDate
                       };
                return result.ToList();

            }
        }
    }
}
