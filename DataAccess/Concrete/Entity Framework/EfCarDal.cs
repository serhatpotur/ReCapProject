using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.Entity_Framework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetProductDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from ca in context.Cars
                             join br in context.Brands
                             on ca.BrandId equals br.Id
                             join co in context.Colors
                             on ca.ColorId equals co.Id
                             select new CarDetailDto
                             {
                                 CarId = ca.Id,
                                 BrandName = br.BrandName,
                                 Description = ca.Description,
                                 ColorName = co.ColorName,
                                 DailyPrice = ca.DailyPrice
                             };
                return result.ToList();
            }
        }



        //public void Add(Car entity)
        //{
        //    using (ReCapProjectContext context = new ReCapProjectContext())
        //    {
        //        var addedCar = context.Entry(entity);
        //        addedCar.State = EntityState.Added;
        //        context.SaveChanges();
        //    }
        //}

        //public void Delete(Car entity)
        //{
        //    using (ReCapProjectContext context = new ReCapProjectContext())
        //    {
        //        var deletedCar = context.Entry(entity);
        //        deletedCar.State = EntityState.Deleted;
        //        context.SaveChanges();
        //    }
        //}

        //public Car Get(Expression<Func<Car, bool>> filter)
        //{
        //    using (ReCapProjectContext context = new ReCapProjectContext())
        //    {
        //        return context.Set<Car>().SingleOrDefault(filter);
        //    }
        //}

        //public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        //{
        //    using (ReCapProjectContext context = new ReCapProjectContext())
        //    {
        //        return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
        //    }
        //}

        //public void Update(Car entity)
        //{
        //    using (ReCapProjectContext context = new ReCapProjectContext())
        //    {
        //        var updatedCar = context.Entry(entity);
        //        updatedCar.State = EntityState.Modified;
        //        context.SaveChanges();
        //    }
        //}
    }
}
