using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AntiSerum.Client.Models
{
    public class WordValidation
    {
        [Required]
        [StringLength(30, ErrorMessage = "Word is too long.")]
        public string Word { get; set; }
    }
}
