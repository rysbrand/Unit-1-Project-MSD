using System.ComponentModel.DataAnnotations;

namespace Unit_1_Project.Models
{
    public class Genre
    {
        [Required(ErrorMessage = "choose a genre.")]
        public string GenreID { get; set; } = string.Empty;

        public string genre { get; set; } = string.Empty;

    }
}
