using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            var rentedCarList = _rentalDal.GetAll(r => r.CarId == rental.CarId);
            foreach (var car in rentedCarList)
            {
                if (car.ReturnDate == null)
                {
                    return new ErrorResult(Messages.NoRental);
                }
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);

        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<Rental>> GetCustomerById(int customerId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(q => q.CustomerId == customerId));

        }

        public IDataResult<List<Rental>> GetCarById(int carId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(q => q.CarId == carId));

        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }
    }
}
