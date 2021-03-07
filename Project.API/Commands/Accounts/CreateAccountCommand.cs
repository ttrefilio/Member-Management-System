namespace Project.API.Commands.Accounts
{
    public class CreateAccountCommand
    {
        public string Status { get; set; }
        public int Balance { get; set; }
        public string MemberId { get; set; }
        public string CompanyId { get; set; }
    }
}
