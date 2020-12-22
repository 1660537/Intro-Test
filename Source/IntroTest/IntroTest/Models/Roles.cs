using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntroTest.Models
{
    public class Roles
    {
        [Key]
        [Required]
        [Column("Id")]
        public int Id { get; set; }
        [Required]
        [Column("Name")]
        public string Name { get; set; }
    }
}
