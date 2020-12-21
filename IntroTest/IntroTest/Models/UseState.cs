using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntroTest.Models
{
    public class UseState
    {
        [Key]
        [Required]
        [Column("IdRole")]
        public int IdRole { get; set; }
        [Required]
        [Column("Date")]
        public DateTime Date { get; set; }
        [Required]
        [Column("Token")]
        public string Token { get; set; }
    }
}
