using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Models
{
    // TODO: Student Name : Shareen Banu Shaik
    // TODO:  Student ID : 9081360

    public class Movie
    {
        public int Id { get; set; }

        // Required + Must start with capital letter
        [Required(ErrorMessage = "Title is required.")]
        [RegularExpression(@"^[A-Z].*", ErrorMessage = "Title must start with a capital letter.")]
        public string Title { get; set; } = string.Empty;

        // Must be int, not string
        [Display(Name = "Release Year")]
        [Range(1900, 2025, ErrorMessage = "Release Year must be between 1900 and 2025.")]
        public int ReleaseYear { get; set; }

        // Must be one of allowed genres
        [Required(ErrorMessage = "Genre is required.")]
        [RegularExpression(@"^(Action|Comedy|Drama|Horror|SciFi)$",
            ErrorMessage = "Genre must be Action, Comedy, Drama, Horror, or SciFi.")]
        public string Genre { get; set; } = string.Empty;

        // Display name change
        [Display(Name = "Image URL")]
        [Required(ErrorMessage = "Image URL is required.")]
        public string ImgUrl { get; set; } = string.Empty;
    }
}