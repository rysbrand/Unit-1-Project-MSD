using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Unit_1_Project.Models
{
    public class Book
    {
        public int bookID { get; set; }

        [Required(ErrorMessage = "Please enter a title.")]
        public string title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a year")]
        [Range(1400, 2999, ErrorMessage = "Year must be between 1400 - 2999")]
        public int? year { get; set; }

        [Required(ErrorMessage = "Please enter a rating")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int? rating { get; set; }

        [Required(ErrorMessage = "Please enter a Genre")]
        public string GenreID { get; set; } = string.Empty;

        [ValidateNever]
        public Genre? Genre { get; set; } = null!;

        public string Slug => title?.Replace(' ', '-').ToLower() + '-' + year?.ToString();
    }
}
