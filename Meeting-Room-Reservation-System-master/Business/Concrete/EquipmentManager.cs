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

    public class EquipmentManager : IEquipmentService
    {
   
        IEquipmentDal _equipmentDal;

        public EquipmentManager(IEquipmentDal equipmentDal)
        {
          
            _equipmentDal = equipmentDal;
        }

        public IResult CreateEquipment(Equipment equipment)
        {
            IResult result = BusinessRules.Run(CheckIfRoomNameExists(equipment.EquipmentName));
            if (!result.Success)
            {
                return result;
            }
            _equipmentDal.Add(equipment);
            return new SuccessDataResult<Equipment>(Messages.EquipmentAdded);
        }

        private IResult CheckIfRoomNameExists(string equipmentName)
        {
            var result = _equipmentDal.GetAll(p => p.EquipmentName == equipmentName).FirstOrDefault();
            if (result == null)
            {
                return new SuccessResult();
            }

            return new ErrorDataResult<Equipment>(Messages.EquipmentNameInvalid);
        }

        public IResult DeleteEquipment(Equipment equipment)
        {
            var deletedEquipment = _equipmentDal.Get(p => p.EquipmentId == equipment.EquipmentId);
            if (deletedEquipment == null)
            {
                return new ErrorDataResult<Equipment>(Messages.ThisEquipmentisNotFound);

            }
            _equipmentDal.Delete(equipment);
            return new SuccessResult(Messages.EquipmentIsDeleted);
        }

        public IDataResult<List<Equipment>> GetAllEquipments()
        {
            return new SuccessDataResult<List<Equipment>>(_equipmentDal.GetAll());
        }

        public IDataResult<List<Equipment>> GetEquipmentById(int id)
        {
            return new SuccessDataResult<List<Equipment>>(_equipmentDal.GetAll(p => p.EquipmentId == id));
        }

        public IResult UpdateEquipment(Equipment equipment)
        {
            var updatedEquipment = _equipmentDal.Get(r => r.EquipmentId == equipment.EquipmentId);
            if (updatedEquipment == null)
            {
                return new ErrorDataResult<Equipment>(Messages.EquipmentNotFound);
            }



            // Veritabanındaki oda bilgilerini güncelle
            updatedEquipment.EquipmentName = equipment.EquipmentName;
            updatedEquipment.RoomToEquipments = equipment.RoomToEquipments;
            // Diğer özellikler...

            _equipmentDal.Update(equipment);
            return new SuccessResult(Messages.EquipmentUpdated);
        }

        public IDataResult<List<Equipment>> GetEquipmentByName(string equipmentName)
        {
            return new SuccessDataResult<List<Equipment>>(_equipmentDal.GetAll(p => p.EquipmentName==equipmentName));
        }
    }
}
