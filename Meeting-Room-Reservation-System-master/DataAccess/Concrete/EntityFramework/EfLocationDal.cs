using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity;
using Entity.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfLocationDal : EfEntityRepositoryBase<Location, MeetingWebContext>, ILocationDal
    {
        public List<Location> GetLocationsByAdress(string city)
        {
            using (var contex = new MeetingWebContext())
            {
                var locations = contex.Locations.Where(locations => locations.Adress == city).ToList();
                return locations;
            }
        }


        // Diğer CRUD operasyonları ve özel fonksiyonlar burada olabilir

        public IEnumerable<LocationWithRoomCountDTO> GetLocationsWithRoomCount()
        {
            using (var context = new MeetingWebContext())
            {
                var locationsWithRoomCount = context.Locations
                .Select(location => new LocationWithRoomCountDTO
                {
                    LocationId = location.LocationId,
                    LocationName = location.LocationName,
                    Adress = location.Adress,
                    RoomCount = location.RoomCount
                })
                .ToList();

                return locationsWithRoomCount;
            }
        }

        public List<Room> GetRoomsByLocationId(int locationId)
        {
            using (var context = new MeetingWebContext())
            {
                var rooms = context.Rooms
                    .Where(room => room.LocationId == locationId)
                    .ToList();

                return rooms;
            }
        }

        public List<Room> GetRoomsByLocationName(string locationName)
        {
            using (var context = new MeetingWebContext())
            {
                var location = context.Locations
                    .FirstOrDefault(l => l.LocationName == locationName);

                if (location != null)
                {
                    var roomsInLocation = context.Rooms
                        .Where(room => room.LocationId == location.LocationId)
                        .ToList();

                    return roomsInLocation;
                }

                return new List<Room>();
            }
        }
    }
}

