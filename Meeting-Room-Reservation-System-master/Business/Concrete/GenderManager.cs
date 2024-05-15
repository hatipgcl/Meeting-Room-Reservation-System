using Business.Abstract;
using Business.Constanst;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class GenderManager : IGenderService
    {
        IGenderDal _genderDal;
      
        public GenderManager( IGenderDal genderDal)
        {
            _genderDal = genderDal;
         
        }
        public IDataResult<List<Gender>> GetAllGenders()
        {
            return new SuccessDataResult<List<Gender>>(_genderDal.GetAll(),Messages.GendersListed);
        }

        public IDataResult<List<Gender>> GetGenderById(int id)
        {
            return new SuccessDataResult<List<Gender>>(_genderDal.GetAll(p => p.GenderId == id));

        }

        public IDataResult<List<Gender>> GetGenderByName(string name)
        {
            return new SuccessDataResult<List<Gender>>(_genderDal.GetAll(p => p.GenderName == name));
        }
    }
}
