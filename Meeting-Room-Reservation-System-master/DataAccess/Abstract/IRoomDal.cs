using Core.DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRoomDal : IEntityRepository<Room>
    {
        List<Room> GetRoomsByLocationId(int locationId); //Belirli bir konuma ait tüm toplantı odalarını getir
        List<Room> GetAvailableRoomsByDateRange(DateTime startDate, DateTime endDate); //Belirli bir tarih aralığında boş olan toplantı odalarını getir
        List<Room> GetRoomsByCapacity(int maxCapacity);//Belirli bir kapasite aralığındaki toplantı odalarını getir
        List<Room> GetRoomsByLocationName(string locationName);
        List<Room> GetRoomsByEquipment(List<string> equipmentNames);
    }
}
