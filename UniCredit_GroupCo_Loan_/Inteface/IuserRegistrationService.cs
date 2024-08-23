using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniCredit_GroupCo_Loan.BusinessEntities.ModelDtos;

namespace UniCredit_GroupCo_Loan.BusinessEntities.Intefrace
{
      public interface IuserRegistrationService
    {
        Task<List<UserRegistrationDtos>> GetAllUserRegistrations();
        Task<UserRegistrationDtos> GetAllUserRegistrationById(int Id);
        Task<bool> AddUserRegistration(UserRegistrationDtos userregdetail);
        Task<bool> UpdateUserRegistration(UserRegistrationDtos userregdetail);
        Task<bool> DelateUserRegistation(int Id);
    }
}
