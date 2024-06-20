using System;
using System.ComponentModel.DataAnnotations;

namespace PhotoApp.Models
{
    public class Photo
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string FilePath { get; set; }

        public DateTime UploadDate { get; set; }
    }
}
