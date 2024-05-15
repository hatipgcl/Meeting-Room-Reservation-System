using Core.DataAccess;
using Entity;
using Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ILocationDal :IEntityRepository<Location>
    {
   //Belirli bir şehre ait tüm hizmet binalarını getiren bir fonksiyon olabilir. 
      IEnumerable<LocationWithRoomCountDTO> GetLocationsWithRoomCount(); // Hizmet binalarıyla birlikte toplantı odası sayılarını döndüren bir fonksiyon olabilir.
     List<Location> GetLocationsByAdress(string city);
        List<Room> GetRoomsByLocationId(int locationId);
        List<Room> GetRoomsByLocationName(string locationName);
    }
}
