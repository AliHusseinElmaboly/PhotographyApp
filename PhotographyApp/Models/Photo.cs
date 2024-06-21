using System;
using System.ComponentModel.DataAnnotations;

namespace PhotoApp.Models
{
    /// <summary>
    /// Represents a photo entity.
    /// </summary>
    public class Photo
    {
        /// <summary>
        /// Gets or sets the unique identifier for the photo.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the photo.
        /// </summary>
        [Required(ErrorMessage = "The Title field is required.")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description of the photo.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the file path of the photo.
        /// </summary>
        [Required(ErrorMessage = "The FilePath field is required.")]
        public string FilePath { get; set; }

        /// <summary>
        /// Gets or sets the upload date of the photo.
        /// </summary>
        public DateTime UploadDate { get; set; }
    }
}
