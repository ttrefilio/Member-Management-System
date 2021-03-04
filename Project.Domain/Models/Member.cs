using System;
using System.Collections.Generic;

namespace Project.Domain.Models
{
    public class Member
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Account> Accounts { get; set; }
    }
}
