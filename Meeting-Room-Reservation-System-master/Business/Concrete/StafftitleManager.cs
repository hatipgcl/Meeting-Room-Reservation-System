using Business.Abstract;
using Business.Constanst;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class StafftitleManager : IStafftitleService
    {
        
        IStafftitleDal _stafftitleDal;

        public StafftitleManager(IStafftitleDal stafftitleDal)
        {
       
        _stafftitleDal= stafftitleDal;
        }

        public IResult Add(Stafftitle stafftitle)
        {


            IResult result = BusinessRules.Run(CheckIfRoomNameExists(stafftitle.StafftitleName));
            if (!result.Success)
            {
                return result;
            }
            _stafftitleDal.Add(stafftitle);
            return new SuccessResult(Messages.StafftitleAdded);
        }
        private IResult CheckIfRoomNameExists(string stafftitleName)
        {
            var result = _stafftitleDal.GetAll(p => p.StafftitleName==stafftitleName).FirstOrDefault();
            if (result == null) 
            {
                return new SuccessResult();
            }

            return new ErrorResult(Messages.StafftiltleNameInvalid);


        }

        public IDataResult<List<Stafftitle>> GetAllStafftitles()
        {
            return new SuccessDataResult<List<Stafftitle>>(_stafftitleDal.GetAll(), Messages.StafftitlesListed);
        }

        public IDataResult<List<Stafftitle>> GetById(int id)
        {
            return new SuccessDataResult<List<Stafftitle>>(_stafftitleDal.GetAll(p => p.StafftitleId == id));
        }

        public IDataResult<List<Stafftitle>> GetStafftitlesByName(string stafftitleName)
        {
            return new SuccessDataResult<List<Stafftitle>>(_stafftitleDal.GetAll(p => p.StafftitleName== stafftitleName));
            
        }

        public IResult Remove(Stafftitle stafftitle)
        {
            var result = _stafftitleDal.Get(p => p.StafftitleId == stafftitle.StafftitleId);
            if (result == null)
            {
                return new ErrorResult(Messages.ThisStaftitleisNotFound);

            }
            _stafftitleDal.Delete(stafftitle);
            return new SuccessResult(Messages.StafftitleIsDeleted);
        }

        public IResult Update(Stafftitle stafftitle)
        {
            var result = _stafftitleDal.Get(r => r.StafftitleId == stafftitle.StafftitleId);
            if (result == null)
            {
                return new ErrorResult(Messages.StafftitleNotFound);
            }

            /*Güncelleme işlemi için gerekli iş kurallarını kontrol edelim
            IResult resultControl = BusinessRules.Run(/* Diğer iş kuralları );
            if (!resultControl.Success)
            {
                return resultControl;
            }*/

            // Veritabanındaki oda bilgilerini güncelle
            result.StafftitleName = stafftitle.StafftitleName;
            // Diğer özellikler...

            _stafftitleDal.Update(result);
            return new SuccessResult(Messages.StafftitleUpdated);
        }
    }
}
