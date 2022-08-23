using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSample.Data
{
    [Table("AspNetRoles", Schema = "dbo")]
    public class AspNetRole : IdentityRole
    {
    }

    [Table("AspNetUserRoles", Schema = "dbo")]
    public class AspNetUserRole : IdentityUserRole<string>
    {
    }

    public static class AuthRoles
    {
        public const string Administrator = "Administrator";
        public const string User = "User";
    }
}
