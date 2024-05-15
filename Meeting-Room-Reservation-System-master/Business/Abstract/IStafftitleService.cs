using Core.Utilities.Results;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IStafftitleService
    {
        IDataResult<List<Stafftitle>> GetAllStafftitles();
        IDataResult<List<Stafftitle>> GetById(int id);

        IDataResult<List<Stafftitle>> GetStafftitlesByName(string stafftitleName);
        IResult Add(Stafftitle stafftitle);
        IResult Remove(Stafftitle stafftitle);
        IResult Update(Stafftitle stafftitle);

    }
}
