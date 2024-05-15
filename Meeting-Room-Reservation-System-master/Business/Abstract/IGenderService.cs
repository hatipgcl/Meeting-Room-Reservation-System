using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGenderService
    {

        IDataResult<List<Gender>> GetAllGenders();

        IDataResult<List<Gender>> GetGenderById(int id);
        IDataResult<List<Gender>> GetGenderByName(string name);





    }
}
