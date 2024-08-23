using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniCredit_GroupCo_Loan.DataBaselogic;
using UniCredit_GroupCo_Loan.BusinessEntities;
using UniCredit_GroupCo_Loan.BusinessEntities.Intefrace;
using UniCredit_GroupCo_Loan.DataBaselogic.HotelManagementDBModel;
using Microsoft.EntityFrameworkCore;

namespace UniCredit_GroupCo_Loan.RepositoryLayer
{ 
    public class UserRegistrationRepository : IUserRegistrationRepository
    {
        public HotelManagementContext  _hotelManagementCon;
        public UserRegistrationRepository(HotelManagementContext hotelManagementCon)
        {
            _hotelManagementCon = hotelManagementCon;
        }
        public async Task<bool> AddUserRegistration(UserRegistration userregdetail)
        {
            await _hotelManagementCon.UserRegistrations.AddAsync(userregdetail);
            _hotelManagementCon.SaveChanges();
            return true;
        }                

        public async Task<bool> DelateUserRegistation(int Id)
        {
           UserRegistration ur = _hotelManagementCon.UserRegistrations.SingleOrDefault(e => e.Id == Id);
            if (ur == null)
            {
                _hotelManagementCon.UserRegistrations.Remove(ur);
                _hotelManagementCon.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public async Task<UserRegistration> GetAllUserRegistrationById(int Id)
        {
          var rm = await _hotelManagementCon.UserRegistrations.Where(e => e.Id == Id).FirstOrDefaultAsync();
         
            if (rm == null)
                return null;
            else
                return rm;
        }

    

        public async Task<List<UserRegistration>> GetAllUserRegistrations()
        {
            var rm = _hotelManagementCon.UserRegistrations.ToList();
            if (rm.Count == 0)
                return null;
            else return rm;
        }

        public async Task<bool> UpdateUserRegistration(UserRegistration userregdetail)
        {
            _hotelManagementCon.Update(userregdetail);
            await _hotelManagementCon.SaveChangesAsync();
            return true;
        }
    }



}
