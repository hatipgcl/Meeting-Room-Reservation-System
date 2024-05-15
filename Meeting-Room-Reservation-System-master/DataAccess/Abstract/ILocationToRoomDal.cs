using Core.DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public   interface ILocationToRoomDal : IEntityRepository<LocationToRoom>
    {
        List<LocationToRoom> GetRoomsByLocationId(int locationId);
        List<LocationToRoom> GetRoomsByLocationName(string locationName);
    }
}
