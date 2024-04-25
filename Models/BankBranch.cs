namespace apiTest.Models
{
    using System.ComponentModel.DataAnnotations;

    
    
        public class BankBranch
        {

            public int Id { get; set; }
            public string LocationName { get; set; }

            [DataType(DataType.Url)]
            public string LocationURL { get; set; }

            public string BranchManager { get; set; }

            [Range(1, 100)]
            public int EmployeeCount { get; set; }

            public List<Employee> Employees { get; set; }


        }
    }


