using Core.Utilities.Results;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEquipmentService
    {
        IDataResult<List<Equipment>> GetAllEquipments();

        IDataResult<List<Equipment>> GetEquipmentById(int id);
        IDataResult<List<Equipment>> GetEquipmentByName(string equipmentName);
        IResult CreateEquipment(Equipment equipment);

        IResult UpdateEquipment(Equipment equipment);

        IResult DeleteEquipment(Equipment equipment);

    }
}
