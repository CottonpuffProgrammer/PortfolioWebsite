﻿using System.ComponentModel.DataAnnotations;

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
        /// Description of the contents of a photo / alt text
        /// </summary>
        [Required]
        public string PhotoDescription { get; set; }

        /// <summary>
        /// Name of a photo / actual file name
        /// </summary>
        [Required]
        public string PhotoName { get; set; }

        // To Do: Add a way to actually contain a photo to display
    }
}
