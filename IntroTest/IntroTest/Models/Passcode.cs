using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IntroTest.Models
{
    public class Passcode
    {
        [Key]
        [Required]
        [Column("IdRole")]
        public int IdRole { get; set; }
        [Key]
        [Required]
        [Column("Code")]
        public string Code { get; set; }
    }
}
