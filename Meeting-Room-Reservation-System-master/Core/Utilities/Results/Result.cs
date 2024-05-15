using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {

        public Result(bool success, string message) : this(success)
        {//this sınıfı gösterriri.Resultun tek parametreli ctor una sucess i yolla
         // otomatik ikisi de çalışır. 
         //Success = success; bunu siliyoz çünkü tek kod bir kere.
            Message = message; //get ler ctorlarda set edilebilir

        }
        public Result(bool success)
        {
            Success = success;
            //overloding. Hem bunu hem diğer ctor istenilidiği gibi kullanılabilr
            //farklı imzalarla kullanılabilir aynı ctor
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
