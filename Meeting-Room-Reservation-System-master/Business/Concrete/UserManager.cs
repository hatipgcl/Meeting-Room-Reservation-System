using Business.Abstract;
using Business.Constanst;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
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
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }


        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            var result = _userDal.GetAll(p => p.UserId == user.UserId);
            if (result == null)
            {
                return new ErrorResult(Messages.ThisUserİsFound);

            }

            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public int CalculateAge(User user)
        {
            var birthdayYear = user.Birthday.Value.Year;
            DateTime currentDate = DateTime.Today;
            int age = currentDate.Year - birthdayYear;
            return age;
        }

        public IResult Delete(User user)
        {
            var result = _userDal.Get(p => p.UserId ==user.UserId);
            if (result == null)
            {
                return new ErrorResult(Messages.ThisUserisNotFound);

            }
            _userDal.Delete(result);
            return new SuccessResult(Messages.UserIsDeleted);
        }



        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public IResult GetUserById(int id)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(p => p.UserId == id));
        }

        public IResult GetUserByName(string userName)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(p => p.UserName == userName));
        }


        public IDataResult<List<User>> ListAllUsers()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.AllUsersListed);
        }

        public IResult Update(User user)
        {
            var result = _userDal.Get(r => r.UserId == user.UserId);
            if (result == null)
            {
                return new ErrorResult(Messages.ThisUserİsNotFound);
            }
            result.UserName = user.UserName;
            result.UserSurname = user.UserSurname;
            result.Stafftitle = user.Stafftitle;
            result.Birthday = user.Birthday;
            result.Gender = user.Gender;
            result.Stafftitle = user.Stafftitle;

            // Diğer özellikler...

            _userDal.Update(result);
            return new SuccessResult(Messages.UserIsUpdated);
        }
        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

   

      
    }
}

