﻿using apiTest.Models;
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

      


        [HttpPatch("{id}")]
        public IActionResult Edit(int id,AddBankRequest request)
        {
            var bank = _context.BankBranches.Find(id);
            bank.LocationName = request.Name;
            bank.BranchManager = request.BranchManger;
            bank.LocationURL = request.Location;
            _context.SaveChanges();

            return Created(nameof(Details), new { Id = bank.Id });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var bank = _context.BankBranches.Find(id);
            _context.BankBranches.Remove(bank);
            _context.SaveChanges();

            return Created(nameof(Details), new { Id = bank.Id });

        }




        [HttpGet("{id}")]
        public ActionResult <BankBranchResponse>  Details(int id)
        {
            var bank = _context.BankBranches.Find(id);
            if (bank == null)
            {
                return NotFound();
            }
            return new BankBranchResponse {  BranchManger= bank.BranchManager,
                Location = bank.LocationURL,
                Name = bank.LocationName };

        }
        [HttpGet]
        public IEnumerable<BankBranch> GetAll(string? searchTerm, [FromQuery] BankFilter filter, int pageNumber = 1, int pageSize = 10)
        {
            var banks = _context.BankBranches.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                banks = banks.Where(c => c.LocationName.Contains(searchTerm));
                var pagedBanks = banks
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
                return pagedBanks;
            }
            else return _context.BankBranches;
         // return Ok(customers.ToList()); 
        }

        [HttpPost]
        public IActionResult AddBranch(AddBankRequest request)
        {
            var branch = new BankBranch() { LocationName = request.Name,
                LocationURL= request.Location,
                BranchManager=request.BranchManger };

            _context.BankBranches.Add(branch);
            _context.SaveChanges();
            return Created();
        }
    }
}