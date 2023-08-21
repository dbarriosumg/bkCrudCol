using CRUD_APIS.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CRUD_APIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DataContext _context;
        public EmployeeController(DataContext context) { 
            
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployee()
        {
            return Ok(await _context.Employees.ToListAsync()); 
        }

        [HttpPost]

        public async Task<ActionResult<bool>> CreateEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return true;
        }

        [HttpPut]

        public async Task<ActionResult<bool>> UpdateEmployee(Employee employee)
        {
            var dbEmployee = await _context.Employees.FindAsync(employee.Id);
            if (dbEmployee == null)
                return false;

            dbEmployee.FirstName = employee.FirstName;
            dbEmployee.LastName = employee.LastName;
            dbEmployee.Dpi = employee.Dpi;
            dbEmployee.Gender = employee.Gender;
            dbEmployee.MaritalStatus = employee.MaritalStatus;
            dbEmployee.Nit = employee.Nit;
            dbEmployee.NoIggs = employee.NoIggs;
            dbEmployee.NoIrtra = employee.NoIrtra;
            dbEmployee.PhoneNumber = employee.PhoneNumber;
            dbEmployee.Address = employee.Address;
            dbEmployee.Email = employee.Email;

            await _context.SaveChangesAsync();

            return true;
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteEmployee(int id)
        {
            var dbEmployee = _context.Employees.Find(id);
            if (dbEmployee == null)
                return false;
             
               _context.Employees.Remove(dbEmployee);
            await _context.SaveChangesAsync();
                return true;
        }
    }
}
