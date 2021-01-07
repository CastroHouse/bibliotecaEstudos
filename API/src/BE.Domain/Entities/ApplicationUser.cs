using System;
using Microsoft.AspNetCore.Identity;

namespace BE.Domain.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid();
            ActiveStatus = true;
            CreatedDate = DateTime.Now;
        }
        public DateTime CreatedDate { get; set; }
        public bool ActiveStatus { get; set; }
        public virtual Usuario Usuario {get;set;}
    }
}