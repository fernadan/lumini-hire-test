using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LuminiHire.Models
{
    public class Search
    {
        [Required]
        [MinLength(3)]
        public string query { get; set; }
    }
}
