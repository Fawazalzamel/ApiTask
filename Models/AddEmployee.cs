namespace apiTest.Models
{
    public class AddEmployee
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public double civilID { get; set; }

        public string Position { get; set; }

    }

    public class EmployeeResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double civilID { get; set; }

        public string Position { get; set; }

        public BankBranch WorkplaceId { get; set; }

    }
}
