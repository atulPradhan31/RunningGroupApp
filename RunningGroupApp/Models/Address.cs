using System.ComponentModel.DataAnnotations;

namespace RunningGroupApp.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Street can't be blank")]
        public string? Street { get; set; }

        [Required(ErrorMessage = "city can't be blank")]
        public string? City { get; set; }

        [Required(ErrorMessage = "State can't be blank")]
        public string? State { get; set; }
    }
}
