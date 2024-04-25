using apiTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankController : Controller
    {

        private readonly BankContext _context;

        public BankController(BankContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IEnumerable<BankBranch> GetAll()
        {

            return _context.BankBranches;

        }

        [HttpPost]
        public IActionResult AddBranch(AddBankRequest request)
        {
            var branch = new BankBranch() { LocationName = request.Name, LocationURL= request.Location, BranchManager=request.BranchManger };

            _context.BankBranches.Add(branch);
            _context.SaveChanges();
            return Created();
        }
    }
}