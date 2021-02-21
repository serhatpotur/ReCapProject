using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        /*
        * CarManager "_carDal.GetAll(), true, Messages.ProductsListed" yazan kısım
        * Bizim T Data olarak yazdığımız kısıma gelir

        */
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }
        public ErrorDataResult(T data) : base(data, false)
        {

        }
        public ErrorDataResult(string message) : base(default, false, message)
        {
            // default , datanın default değeridir
        }
        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
