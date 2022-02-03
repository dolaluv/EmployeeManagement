using EmployeeManagement.Helpers;

namespace EmployeeManagement.Abstractions
{
    public interface IAdminUsers
    {
        Task<bool> AdminUserLogin(string username, string password);
        Task<bool> AddEmployee(EmployeeModel employeeModel); 
        Task<List<EmployeeModel>> GetAllUser();
        Task<List<EmployeeModel>> GetEmployeeByCriteria(string searchparam);



    }
}
