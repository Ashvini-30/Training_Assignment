
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

namespace WebApplication3.Models
{
    public class UserRole
    {
        [Key]
        public int Id { get; set; }
        public virtual  User UserId { get; set; }
        public  virtual Role RoleId { get; set; }
    }
}