using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCEmployee.Models
{
   
        public class UsersContext : DbContext
        {
            public UsersContext()
                : base("DefaultConnection")
            {
            }

            public DbSet<UserProfile> UserProfiles { get; set; }
        }

        [Table("UserProfile")]
        public class UserProfile
        {
            [Key]
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int UserId { get; set; }
            public string UserName { get; set; }
        }

        public class LoginModel
        {
            [Required(ErrorMessage = "Please Enter Valid UserName")]
            [Display(Name = "User name")]
            public string UserName { get; set; }

            [Required(ErrorMessage = "Please Enter Valid Password")]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }
           
        }
    
}