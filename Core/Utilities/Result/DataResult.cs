using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, bool success, string message) : base(success, message)
        {
            //data = Data;
            Data = data;
        }
        public DataResult(T data, bool success) : base(success)
        {
            //data = Data;
            Data = data;
        }
        public T Data { get; }

    }
}
