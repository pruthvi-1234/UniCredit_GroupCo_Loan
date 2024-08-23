using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniCredit_GroupCo_Loan.BusinessEntities.Intefrace;
using UniCredit_GroupCo_Loan.BusinessEntities.ModelDtos;

namespace UniCredit_GroupCo_Loan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IuserRegistrationService _userRegistrationService;
        public UsersController(IuserRegistrationService userRegistrationService)
        {
            _userRegistrationService = userRegistrationService;
        }

        [HttpGet(Name = "GetAllUserRegistrations")]
        public async Task<IActionResult> GetAllUserRegistrations()
        {
            try
            {
                var userdata = await _userRegistrationService.GetAllUserRegistrations();
                if (userdata != null)
                {
                    return StatusCode(StatusCodes.Status200OK, userdata);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Bad input request");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }
        [HttpPost]
        [Route("AddUserRegistration")]
        public async Task<IActionResult> Post([FromBody] UserRegistrationDtos userregdetail)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                var userdata = await _userRegistrationService.AddUserRegistration(userregdetail);
                return StatusCode(StatusCodes.Status201Created, "userregistrtion  Added Succesfully");
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }

        [HttpGet]
        [Route("GetAllUserRegistrationById/{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            if (Id < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Bad input request");
            }
            try
            {
                var userdata = await _userRegistrationService.GetAllUserRegistrationById(Id);
                if (userdata == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "userId  not found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, userdata);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }

        [HttpDelete]
        [Route("DelateUserRegistation/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            if (Id < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Bad input request");
            }

            try
            {
                var usrdata = await _userRegistrationService.DelateUserRegistation(Id);
                if (usrdata == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "user Id not found");
                }
                else
                {
                    var Data = await _userRegistrationService.DelateUserRegistation(Id);
                    return StatusCode(StatusCodes.Status204NoContent, "user details deleted successfully");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }

        [HttpPut]
        [Route("UpdateUserRegistration")]
        public async Task<IActionResult> PUT([FromBody] UserRegistrationDtos usrdto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                var usrdata = await _userRegistrationService.UpdateUserRegistration(usrdto);
                return StatusCode(StatusCodes.Status201Created, " user Details Updated Succesfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }
    }
}
