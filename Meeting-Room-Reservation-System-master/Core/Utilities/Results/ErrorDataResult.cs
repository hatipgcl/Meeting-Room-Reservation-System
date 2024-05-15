using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {
            //bana data ver ve mesage ver. Bu işlemin sonucu datadır işlem sonucu true mesaj budur.

        }
        public ErrorDataResult(T data) : base(data, false)
        {
            //data verir, işlem sonucu false
        }
        public ErrorDataResult(string message) : base(default, false, message)
        {

            //mesaj budur
        }
        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
