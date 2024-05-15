using Core.DataAccess;
using Core.Entities.Concrete;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataAccess.Abstract
{
    public interface IEquipmentDal : IEntityRepository<Equipment>
    {
       

    }
}
