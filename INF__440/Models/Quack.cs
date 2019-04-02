using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace INF__440.Models
{
    public class Quack
    {
        [Key]
        public int Quack_Id { get; set; }
        
        public string UserId { get; set; }

        [Required]
        [Display(Name ="Quack Title")]
        public string Quack_Title { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name ="Date")]
        public string Date_Created { get; set; }

        [Required]
        [Display(Name ="Quack Text")]
        public string Quack_Text { get; set; }

      
    }

   
}