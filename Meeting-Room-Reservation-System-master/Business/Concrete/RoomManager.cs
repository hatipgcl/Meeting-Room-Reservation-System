using Business.Abstract;
using Business.Constanst;
using Core.Extensions;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RoomManager : IRoomService
    {
       
        IRoomDal _roomDal;

        public RoomManager( IRoomDal roomDal)
        {
           
            _roomDal = roomDal;

        }

        public IResult Add(Room room)
        {
            IResult result = BusinessRules.Run(CheckIfRoomNameExists(room.RoomName));
            if (!result.Success)
            {
                return result;
            }
            _roomDal.Add(room);
            return new SuccessResult(Messages.RoomAdded);
        }

        private IResult CheckIfRoomNameExists(string roomName)
        {
            var result = _roomDal.GetAll(p => p.RoomName == roomName).FirstOrDefault();
            if (result == null)
            {
                return new SuccessResult();
            }

            return new ErrorResult(Messages.RoomNameInvalid);


        }


        public IDataResult<List<Room>> GetAllRooms()
        {
            return new SuccessDataResult<List<Room>>(_roomDal.GetAll(), Messages.RoomsListed);
        }


        public IDataResult<List<Room>> GetById(int id)
        {
            return new SuccessDataResult<List<Room>>(_roomDal.GetAll(p => p.RoomId == id));
        }

        public IDataResult<List<Room>> GetRoomsByEquipment(List<string> equipmentNames)
        {
            {
                try
                {
                    var roomsWithEquipment = _roomDal.GetRoomsByEquipment(equipmentNames);

                    if (roomsWithEquipment.Count == 0)
                    {
                        return new ErrorDataResult<List<Room>>("Sıralanamadı");
                    }

                    return new SuccessDataResult<List<Room>>(roomsWithEquipment, Messages.RoomsWithEquipmentListed);
                }
                catch (Exception ex)
                {
                    return new ErrorDataResult<List<Room>>(ex.Message);
                }
            }
        }


        public IResult Remove(Room room)
        {
            var existingRoom = _roomDal.Get(p => p.RoomId == room.RoomId);
            if (existingRoom == null)
            {
                return new ErrorResult(Messages.ThisRoomisNotFound);

            }
            _roomDal.Delete(room);
            return new SuccessResult(Messages.RoomIsDeleted);
        }

        public IResult Update(Room room)
        {
            var existingRoom = _roomDal.Get(r => r.RoomId == room.RoomId);
            if (existingRoom == null)
            {
                return new ErrorResult(Messages.RoomNotFound);
            }

            // Güncelleme işlemi için gerekli iş kurallarını kontrol edelim
            IResult result = BusinessRules.Run(/* Diğer iş kuralları */);
            if (!result.Success)
            {
                return result;
            }

            // Veritabanındaki oda bilgilerini güncelle
            existingRoom.RoomName = room.RoomName;
            existingRoom.Capasity = room.Capasity;
            // Diğer özellikler...

            _roomDal.Update(existingRoom);
            return new SuccessResult(Messages.RoomUpdated);
        }

        public IDataResult<List<Room>> GetRoomsByCapacity(int capacity)
        {
            try
            {
                var rooms = _roomDal.GetAll(r => r.Capasity >= capacity);

                if (rooms.Count == 0)
                {
                    return new ErrorDataResult<List<Room>>(Messages.RoomNameInvalid);
                }

                return new SuccessDataResult<List<Room>>(rooms, Messages.RoomsListed);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Room>>(ex.Message);
            }
        }

        public IDataResult<List<Room>> GetRoomsByLocationName(string locationName)
        {
            try
            {
                var rooms = _roomDal.GetRoomsByLocationName(locationName);

                if (rooms.Count == 0)
                {
                    return new ErrorDataResult<List<Room>>(Messages.RoomNotFound);
                }

                return new SuccessDataResult<List<Room>>(rooms, Messages.RoomsListed);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Room>>(ex.Message);
            }
        }

       
    }
}



