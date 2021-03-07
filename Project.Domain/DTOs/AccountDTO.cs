using Project.Domain.Enums;
using System;

namespace Project.Domain.DTOs
{
    public class AccountDTO
    {
        public Guid Id { get; set; }       
        public string Name { get { return Company.Name; } }
        public string Status { get; set; }
        public int Balance { get; set; }
        public Guid MemberId { get; set; }

        #region Relationships            
        public CompanyDTO Company { get; set; }
        #endregion

    }
}
