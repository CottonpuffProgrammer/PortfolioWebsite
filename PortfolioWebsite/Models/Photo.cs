using System.ComponentModel.DataAnnotations;

namespace PortfolioWebsite.Models
{
    /// <summary>
    /// Represents a single photo object
    /// </summary>
    public class Photo
    {
        /// <summary>
        /// Uniquely identifies each photo in the database
        /// </summary>
        [Key]
        public int PhotoId { get; set; }

        /// <summary>
        /// The path that refers to the photo contained in 
        /// the wwwroot folder (storage of photos will be 
        /// changed later on)
        /// </summary>
        [Required]
        public string PhotoPath { get; set; }

    }
}
