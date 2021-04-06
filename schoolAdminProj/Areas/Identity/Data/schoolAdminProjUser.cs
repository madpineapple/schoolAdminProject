using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace schoolAdminProj.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the schoolAdminProjUser class
    public class schoolAdminProjUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName="nvarchar(100)")]
        public string Fname { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string Lname { get; set; }
    }
}
