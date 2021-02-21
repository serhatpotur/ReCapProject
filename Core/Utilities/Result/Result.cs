using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result
{
    public class Result : IResult
    {
        public Result(bool success, string message) : this(success)
        {
            /*
             * İşlemin başarılı/başarısız old. dair mesaj vermek istedik
             * Kod tekrarı yapmamak için bu kısma success=Success yazmadık
             * Onun yerine bu ctor'a this(success) dedik
             */
            //message = Message;
            Message = message;

        }
        public Result(bool success)
        {
            // Kullanıcıya işlem başarılı/başarısız olduğunu göstermiş olduk
            //success = Success;
            Success = success;

        }
        public bool Success { get; }

        public string Message { get; }
    }
}
