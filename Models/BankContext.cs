namespace apiTest.Models
{
    using Microsoft.EntityFrameworkCore;

  

        public class BankContext : DbContext
        {
            public BankContext(DbContextOptions<BankContext> options) : base(options)
            {


            }

            public DbSet<BankBranch> BankBranches { get; set; }
            public DbSet<Employee> Employees { get; set; }


        }
    }


