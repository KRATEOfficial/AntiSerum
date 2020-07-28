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
        //When we send the object to the controller, the object will have contexts
        //of what kind of search we want to do
        public bool findOne { get; set; }
    }
}
