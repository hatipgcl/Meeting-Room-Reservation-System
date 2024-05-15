using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
      List<OperationClaim> GetClaims(User user);
        
        IResult Add(User user);
       
        int CalculateAge(User user);
        IResult Delete(User user);
        IResult Update(User user);
        IDataResult<List<User>> ListAllUsers();
        IResult GetUserById(int id);
       
        IResult GetUserByName(string locationName);
        User GetByMail(string email);
      
    }
}
