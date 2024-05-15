using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public interface IResult//temel vodiler için başlangıç.Araç=utilities
    {
        bool Success { get; }
        string Message { get; }
    }
}
