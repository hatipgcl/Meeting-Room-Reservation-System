using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>:IResult
    { //list işlemleri için data geri döndürülmeli o yüzden encapulation ile
        //hem data hem void hem mssage döndürebiliriz.
        T Data { get; }
    }
}
