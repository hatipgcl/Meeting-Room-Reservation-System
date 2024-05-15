using Core.Utilities.Results;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILocationService
    {
        IDataResult<List<Location>> GetAllLocations(); //Tüm hizmet binalarını getirir.
        IDataResult<List<Location>> GetLocationById(int id); //Tüm hizmet binalarını getirir.



       // IDataResult<List<Room>> GetRoomsInLocation(int locationId);

        //IDataResult<List<Room>> GetRoomsInLocation(string locationName);


        IResult AddLocation(Location location);
        IResult UpdateLocation(Location location);

        IResult RemoveLocation(Location location);



    }
}
