namespace apiTest.Models
{
    public class AddBankRequest
    {

        public string Name { get; set; }

        public string Location { get; set;}

        public string BranchManger { get; set;}
    }

    public class BankBranchResponse
    {
        public string Name { get; set; }

        public string Location { get; set; }

        public string BranchManger { get; set; }

    }
}
