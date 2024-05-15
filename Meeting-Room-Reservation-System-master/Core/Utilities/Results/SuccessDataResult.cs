using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data,string message):base(data,true,message)
        {
            //bana data ver ve mesage ver. Bu işlemin sonucu datadır işlem sonucu true mesaj budur.

        }
        public SuccessDataResult(T data):base(data,true)
        {
            //data verir, işlem sonucu ture
        }
        public SuccessDataResult(string message):base(default,true,message)
        {

            //mesaj budur
        }
        public SuccessDataResult():base(default,true)
        {

        }
    }
}
