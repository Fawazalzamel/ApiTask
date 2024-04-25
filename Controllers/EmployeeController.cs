using apiTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiTest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly BankContext _context;
        public EmployeeController(BankContext c)
        {
            _context = c;
        }

        [HttpGet]
        public IEnumerable<Employee> GetAll()
        {

            return _context.Employees;

        }


        [HttpPost("AddEmployee/{id}")] //Branch ID to add the employee to the branch
        public IActionResult AddEmployee(int id,AddEmployee request)
        {
           var b = _context.BankBranches.Find(id);

            var employee = new Employee { Name = request.Name, civilID = request.civilID, 
                Position = request.Position,
                Workplace =b   };

            
            _context.Employees.Add(employee);
            _context.SaveChanges();

            return Created();
           
        }

        [HttpGet("Details/{id}")]
        public ActionResult<EmployeeResponse> Details(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return new EmployeeResponse {
                Name = employee.Name,
                civilID = employee.civilID,
                Position = employee.Position
            };

        }


        [HttpPatch("Edit/{id}")]
        public IActionResult Edit(int id, AddEmployee request)
        {
            var employee = _context.Employees.Find(id);
            employee.Name= request.Name;
            employee.Position= request.Position;
            employee.civilID= request.civilID;
            _context.SaveChanges();

            return Created(nameof(Details), new { Id = employee.Id });
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var employee = _context.Employees.Find(id);
            _context.Employees.Remove(employee);
            _context.SaveChanges();

            return Created(nameof(Details), new { Id = employee.Id });

        }
    }

    
    
}
