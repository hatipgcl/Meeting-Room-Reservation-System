using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfLocationToRoomDal : EfEntityRepositoryBase<LocationToRoom, MeetingWebContext>, ILocationToRoomDal
    {
      

        public List<LocationToRoom> GetRoomsByLocationId(int locationId)
        {
            using (var context = new MeetingWebContext())
            {
                var room = context.LocationToRooms
                .Where(re => re.LocationId == locationId)
                .Select(re => new LocationToRoom() { RoomId=re.RoomId })
                .ToList();

                return room;
            }

        }

        public List<LocationToRoom> GetRoomsByLocationName(string locationName)
        {
            using (var context = new MeetingWebContext())
            {

                var room = context.LocationToRooms
                    .Where(lr => lr.Location.LocationName == locationName)
                    .Select(lr =>new LocationToRoom() { RoomId=lr.RoomId })
                    .ToList();

                return room;
            }
        }

    }
}
