using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntroTest.Models
{
    public class Rating
    {
        [Key]
        [Required]
        [Column("IdRole")]
        public int IdRole { get; set; }
        [Required]
        [Column("Token")]
        public string Token { get; set; }
        [Required]
        [Column("Date")]
        public DateTime Date { get; set; }
        [Required]
        [Column("Point")]
        public int Point { get; set; }
        [Required]
        [Column("Feedback")]
        public string Feedback { get; set; }
    }
}
