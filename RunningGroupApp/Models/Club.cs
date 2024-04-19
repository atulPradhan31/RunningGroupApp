using RunningGroupApp.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RunningGroupApp.Models
{
    public class Club
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title can't be blank")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Description can't be blank")]
        [StringLength(100, MinimumLength = 3, ErrorMessage ="Description should be between 3 and 100 chars")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Image can't be blank")]
        public string? Image { get; set; }

        public ClubCategory ClubCategory { get; set; }

        [ForeignKey("Address")]
        public int? AddressId { get; set; }

        public Address? Address { get; set; }

        [ForeignKey("AppUser")]
        public int? AppUserId { get; set; }

        public AppUser? AppUser { get; set; }
    }
}
