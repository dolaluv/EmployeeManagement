using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Helpers
{
    public class EmployeeModel
    { 
       
        public string FirstName { get; set; }
       
        public string LastName { get; set; }
         
        public DateTime DOB { get; set; }
        
        public string Department { get; set; }
    }
}
