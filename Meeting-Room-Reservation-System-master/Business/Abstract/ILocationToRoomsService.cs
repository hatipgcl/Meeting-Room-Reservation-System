using Core.Utilities.Results;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILocationToRoomsService
    {
        IDataResult<List<LocationToRoom>> GetLocationToRoom();
       IDataResult< List<LocationToRoom>> GetRoomsByLocationName(string locationName);
        IDataResult<List<LocationToRoom>> GetRoomsByLocationId(int id);

    }
}
