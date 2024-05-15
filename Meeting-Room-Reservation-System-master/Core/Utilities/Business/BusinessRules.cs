using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
            //params verirsek içine parametre olarak istediğmiz kadar Iresult verebilriiz
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;//hatalıysa haber veririrz
                }
               

            }
            return null; //değilsek kendi çalışır iş kodunun

        }

    }
}
