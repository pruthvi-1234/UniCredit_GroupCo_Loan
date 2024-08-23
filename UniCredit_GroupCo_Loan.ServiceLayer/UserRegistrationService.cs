using UniCredit_GroupCo_Loan.BusinessEntities;
using UniCredit_GroupCo_Loan.BusinessEntities.ModelDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniCredit_GroupCo_Loan.BusinessEntities.Intefrace;

public class UserRegistrationService : IuserRegistrationService
{
    IUserRegistrationRepository _userregdetail;

    public UserRegistrationService(IUserRegistrationRepository userregdetail)
    {
        _userregdetail = userregdetail;
    }
        public async Task<bool> AddUserRegistration(UserRegistrationDtos userregdetail)
    {
        UserRegistration ur = new UserRegistration();
        // obj.id = bookingDetail.id; because of identity we cant pass here
        ur.Id = userregdetail.Id;
        ur.UserName = userregdetail.UserName;
        ur.Email = userregdetail.Email;
        ur.Password = userregdetail.Password;
        ur.FirstName = userregdetail.FirstName;
        await _userregdetail.AddUserRegistration(ur);
        return true;
    }

    public async Task<bool> DelateUserRegistation(int Id)
    {
        await _userregdetail.DelateUserRegistation(Id);
        return true;
    }

    public async Task<UserRegistrationDtos> GetAllUserRegistrationById(int Id)
    {
        var urobj = await _userregdetail.GetAllUserRegistrationById(Id);

        UserRegistrationDtos urdto = new UserRegistrationDtos();
        urdto.Id = urobj.Id;
        urdto.UserName = urobj.UserName;
        urdto.Email = urobj.Email;
        urdto.Password = urobj.Password;
        urdto.FirstName = urobj.FirstName;

        return urdto;

    }

    public async Task<List<UserRegistrationDtos>> GetAllUserRegistrations()
    {
        List<UserRegistrationDtos> objurreg = new List<UserRegistrationDtos>();
        var result = await _userregdetail.GetAllUserRegistrations();
        foreach (UserRegistration usrpbj in result)
        {
            UserRegistrationDtos obj = new UserRegistrationDtos();
            obj.Id = usrpbj.Id;
            obj.UserName = usrpbj.UserName;
            obj.FirstName = usrpbj.FirstName;
            obj.Email = usrpbj.Email;
            obj.Password = usrpbj.Password;
            objurreg.Add(obj);
        }
        return objurreg;
    }

    public async Task<bool> UpdateUserRegistration(UserRegistrationDtos userregdetail)
    {
        UserRegistration obj = new UserRegistration();
        obj.Id = userregdetail.Id;
        obj.UserName = userregdetail.UserName;
        obj.FirstName = userregdetail.FirstName;
        obj.Password = userregdetail.Password;
        obj.Email = userregdetail.Email;


        await _userregdetail.UpdateUserRegistration(obj);
        return true;
    }
}
    

