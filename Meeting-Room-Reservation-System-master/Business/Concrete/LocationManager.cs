using Business.Abstract;
using Business.Constanst;
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
    public class LocationManager : ILocationService
    {
        
        ILocationDal _locationDal;
        public LocationManager(ILocationDal locationDal)
        {
         
            _locationDal = locationDal;
        }

        public IResult AddLocation(Location location)
        {
            IResult result = BusinessRules.Run(CheckIfRoomNameExists(location.LocationName));
            if (!result.Success)
            {
                return result;
            }
            _locationDal.Add(location);
            return new SuccessResult(Messages.LocationAdded);
        }

        private IResult CheckIfRoomNameExists(string locationName)
        {
            var result = _locationDal.GetAll(p => p.LocationName == locationName).FirstOrDefault();
            if (result == null)
            {
                return new SuccessResult();
            }

            return new ErrorResult(Messages.LocationNameInvalid);
        }

        public IDataResult<List<Location>> GetAllLocations()
        {
            return new SuccessDataResult<List<Location>>(_locationDal.GetAll(), Messages.LocationsListed);
        }

        public IDataResult<List<Location>> GetLocationById(int id)
        {
            return new SuccessDataResult<List<Location>>(_locationDal.GetAll(p => p.LocationId == id));
        }

      

        public IResult RemoveLocation(Location location)
        {
            var existingLocation = _locationDal.Get(p => p.LocationId == location.LocationId);
            if (existingLocation == null)
            {
                return new ErrorResult(Messages.ThisRoomisNotFound);

            }
            _locationDal.Delete(location);
            return new SuccessResult(Messages.RoomIsDeleted);
        }

        public IResult UpdateLocation(Location location)
        {
            var updatedLocation = _locationDal.Get(r => r.LocationId == location.LocationId);
            if (updatedLocation == null)
            {
                return new ErrorResult(Messages.LocationNotFound);
            }

            // Güncelleme işlemi için gerekli iş kurallarını kontrol edelim
            IResult result = BusinessRules.Run(/* Diğer iş kuralları */);
            if (!result.Success)
            {
                return result;
            }

            // Veritabanındaki oda bilgilerini güncelle
            updatedLocation.LocationName = location.LocationName;
            updatedLocation.Adress = location.Adress;
            updatedLocation.RoomCount= location.RoomCount;

            _locationDal.Update(updatedLocation);
            return new SuccessResult(Messages.LocationUpdated);
        }


    }
}

