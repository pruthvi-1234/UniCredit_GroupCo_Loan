using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniCredit_GroupCo_Loan.BusinessEntities.Intefrace
{
    public interface IUserRegistrationRepository
    {
        Task<List<UserRegistration>> GetAllUserRegistrations();
        Task<UserRegistration> GetAllUserRegistrationById(int Id);
        Task<bool> AddUserRegistration(UserRegistration userregdetail);
        Task<bool> UpdateUserRegistration(UserRegistration userregdetail);
        Task<bool> DelateUserRegistation(int Id);
    }
}
