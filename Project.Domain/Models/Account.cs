using Project.Domain.Enums;
using System;

namespace Project.Domain.Models
{
    public class Account
    {
        public Guid Id { get; set; }
        public AccountStatus Status { get; set; }
        public int Balance { get; set; }

        #region Member

        public Guid MemberId { get; set; }
        public Member Member { get; set; }

        #endregion

        #region Company

        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

        #endregion

    }
}
