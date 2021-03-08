using System;
using System.Collections.Generic;

namespace Project.Domain.DTOs
{
    public class MemberDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<AccountDTO> Accounts { get; set; }
    }
}
