using EmployeeManagement.Abstractions;
using EmployeeManagement.Data;
using EmployeeManagement.Helpers;
using EmployeeManagement.Models;
using System.Linq;

namespace EmployeeManagement.Services
{
    public class AdminUserServices : IAdminUsers
    {
      
        private readonly AppDBContext _db;
        public AdminUserServices(AppDBContext appDBContext)
        {
                _db = appDBContext;
        }
        public async Task<bool> AddEmployee(EmployeeModel employeeModel)
        {  
            var result = false;
            try
            {
                Employee employee = new Employee
                {
                    FirstName = employeeModel.FirstName,
                    LastName = employeeModel.LastName,
                    DOB = employeeModel.DOB,
                    Department = employeeModel.Department
                };

                _db.Employees.Add(employee);
                _db.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                //Log The Error
                throw;
            }
            return result;
        }

        public async Task<bool> AdminUserLogin(string username, string password)
        {
            var result = false;
            try
            {
                var FindAdminUser = _db.AdminUser.FirstOrDefault(a => a.Username == username && a.Password == password );
                if(FindAdminUser != null)
                    result = true;

            }
            catch (Exception ex)
            {
                //Log The Error
                throw;
            }
            return result;
        }

        public async Task<List<EmployeeModel>> GetAllUser()
        {
            List<EmployeeModel> employeeModel = new List<EmployeeModel>();
            try
            {
                var FindAdminUser = _db.Employees.ToList();

                foreach (var employee in FindAdminUser)
                {
                    EmployeeModel employeeModel1 = new EmployeeModel();
                    employeeModel1.FirstName = employee.FirstName;
                    employeeModel1.LastName = employee.LastName;
                    employeeModel1.DOB = employee.DOB;
                    employeeModel1.Department = employee.Department; 
                    employeeModel.Add(employeeModel1);
                }
              


            }
            catch (Exception ex)
            {
                //Log The Error
                throw;
            }
            return employeeModel;
        }

        public async Task<List<EmployeeModel>> GetEmployeeByCriteria(string searchparam)
        {
            List<EmployeeModel> employeeModel = new List<EmployeeModel>();
            try
            {
                var normalizedQuery = searchparam?.ToLower() ?? "";
                var FindAdminUser = _db.Employees.ToList();
                var searchResult = FindAdminUser.Where(f => f.FirstName.ToLowerInvariant().Contains(normalizedQuery) || f.LastName.ToLowerInvariant().Contains(normalizedQuery) || f.Department.ToLowerInvariant().Contains(normalizedQuery)).ToList();
                foreach (var employee in searchResult)
                {
                    EmployeeModel employeeModel1 = new EmployeeModel();
                    employeeModel1.FirstName = employee.FirstName;
                    employeeModel1.LastName = employee.LastName;
                    employeeModel1.DOB = employee.DOB;
                    employeeModel1.Department = employee.Department;
                    employeeModel.Add(employeeModel1);
                }
            }
            catch (Exception ex)
            {
                //Log The Error
                throw;
            }
            return employeeModel;
        }
    }
}
