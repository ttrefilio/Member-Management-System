using Project.API.Commands.Accounts;
using System.Collections.Generic;

namespace Project.API.Commands.Members
{
    public class ImportMemberCommand
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<ImportAccountCommand> Accounts { get; set; }
    }
}
