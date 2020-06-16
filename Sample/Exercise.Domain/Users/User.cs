
using Microsoft.AspNetCore.Identity;
using System;

namespace Exercise.Domain.Users
{
    public class User : IdentityUser <Guid>
    {
        public string CustomField { get; set; }
    }
}
