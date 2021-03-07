using Project.API.Commands.Accounts;
using Project.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.API.Commands.Members
{
    public class ImportMemberCommand
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<ImportAccountCommand> Accounts { get; set; }
    }
}
