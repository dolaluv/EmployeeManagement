using EmployeeManagement.Abstractions;
using EmployeeManagement.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        IAdminUsers adminUsers;
        StatusMessage statusMessage = new StatusMessage();
        public AdminController(IAdminUsers _adminUsers)
        {
            adminUsers = _adminUsers;
        }
        [HttpGet("AdminUserLogin")] 
        public async Task<IActionResult> AdminUserLogin(string username, string password)
        {
            try
            {
                var result = await adminUsers.AdminUserLogin(username,password);
                if (result )
                {
                    statusMessage.status = true;
                    statusMessage.message = " Login Successfully";
                    
                }
                else
                {
                    statusMessage.status = false;
                    statusMessage.message = "Invalid Credentials ";
                }

                
               

            }
            catch (Exception ex)
            {
              
            }
            return Ok(statusMessage);
        }


        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmployee( [FromBody] EmployeeModel employeeModel)
        {
            try
            {
                var result = await adminUsers.AddEmployee(employeeModel);
                if (result)
                {
                    statusMessage.status = true;
                    statusMessage.message = "User added Successfully";

                }
                else
                {
                    statusMessage.status = false;
                    statusMessage.message = "Unable to add user";
                } 

            }
            catch (Exception ex)
            {

            }
            return Ok(statusMessage);
        }

        [HttpGet("GetAllEmployee")]
        public async Task<IActionResult> GetAllEmployee()
        {
            try
            {
                var result = await adminUsers.GetAllUser();
                if (result != null)
                {
                    statusMessage.status = true;
                    statusMessage.message = "All added users";
                    statusMessage.Data = result; 
                }
                else
                {
                    statusMessage.status = false;
                    statusMessage.message = "Failed to fetch users";
                } 

            }
            catch (Exception ex)
            {

            }
            return Ok(statusMessage);
        }


        [HttpGet("GetEmployeeBySearchParameter/{searchparam}")]
        public async Task<IActionResult> GetEmployeeBySearchParam( string searchparam)
        {
            try
            {
                var result = await adminUsers.GetEmployeeByCriteria(searchparam);
                if (result != null)
                {
                    statusMessage.status = true;
                    statusMessage.message = "Search Result";
                    statusMessage.Data = result;
                }
                else
                {
                    statusMessage.status = false;
                    statusMessage.message = "Unable to search ";
                }

            }
            catch (Exception ex)
            {

            }
            return Ok(statusMessage);
        }







    }
}
