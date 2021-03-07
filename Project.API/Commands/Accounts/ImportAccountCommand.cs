using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.API.Commands.Accounts
{
    public class ImportAccountCommand
    {        
        public int Balance { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
    }
}
