using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntroTest.Models
{
    public class Customer
    {
        public int PassCode { get; set; }
        public byte Role { get; set; }
    }
}
