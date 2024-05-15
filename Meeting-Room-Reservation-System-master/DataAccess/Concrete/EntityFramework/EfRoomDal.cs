using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRoomDal : EfEntityRepositoryBase<Room, MeetingWebContext>, IRoomDal
    {
        public List<Room> GetAvailableRoomsByDateRange(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public List<Room> GetRoomsByCapacity(int maxCapacity)
        {
            using (var context = new MeetingWebContext())
            {
                var result = context.Rooms.Where(result => result.Capasity == maxCapacity).ToList();
                return result;
            }
        }



        public List<Room> GetRoomsByLocationId(int locationId)
        {
            using (var context = new MeetingWebContext())
            {
                var result = context.Rooms.Where(result => result.LocationId == locationId).ToList();
                return result;
            }
        }

        public List<Room> GetRoomsByEquipment(List<string> equipmentNames)
        {
            using (var context = new MeetingWebContext())
            {
                return context.Rooms
                    .Where(room => room.RoomToEquipments
                        .Any(rte => equipmentNames.Contains(rte.Equipment.EquipmentName)))
                    .ToList();
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
