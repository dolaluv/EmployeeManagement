﻿namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }  
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Department { get; set; }
    }
}
