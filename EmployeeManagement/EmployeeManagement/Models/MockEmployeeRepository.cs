using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employees;
        public MockEmployeeRepository()
        {
                _employees = new List<Employee>()
                {
                    new Employee() { Id = 1, Name = "Mary", Department = Dept.HR, Email = "mary@pragimtech.com" },
                    new Employee() { Id = 2, Name = "John", Department = Dept.IT, Email = "john@pragimtech.com" },
                    new Employee() { Id = 3, Name = "Sam", Department = Dept.Payroll, Email = "sam@pragimtech.com" },
                };
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employees.Max(e => e.Id) + 1;
            _employees.Add(employee);
            return employee;
        }

        public Employee GetEmployee(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employees;
        }

        public Employee Update(Employee employeeChanges)
        {
            Employee employee = _employees.FirstOrDefault(e => e.Id == employeeChanges.Id);
            if (employee != null)
            {
                employee.Name = employeeChanges.Name;
                employee.Email = employeeChanges.Email;
                employee.Department = employeeChanges.Department;
            }
            return employee;
        }

        public Employee Delete(int Id)
        {
            Employee employee = _employees.FirstOrDefault(e => e.Id == Id);
            if (employee != null)
            {
                _employees.Remove(employee);
            }
            return employee;
        }
    }
}
