using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LuminiHire.Models
{
    public class User : IdentityUser
    {
        [Display(Name = "Nome")]
        public string Name { get; set; }
    }
}
