using Core.Utilities.Results;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRoomService
    {
        IDataResult<List<Room>> GetAllRooms(); //çalışıyor
        // IDataResult<List<Room>> GetAvailableRoomsByDateRange(DateTime startDate, DateTime endDate);
        IDataResult<List<Room>> GetRoomsByEquipment(List<string> equipmentNames); //çalıışıyor
        IDataResult<List<Room>> GetById(int id);   
        IDataResult<List<Room>> GetRoomsByCapacity(int capasity);  //çalışıyor
        IDataResult<List<Room>> GetRoomsByLocationName(string location); 
        IResult Add(Room room);
        IResult Remove(Room room);
        IResult Update(Room room);

    }
}
