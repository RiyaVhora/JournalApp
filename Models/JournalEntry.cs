using System;
using System.ComponentModel.DataAnnotations;

namespace JournalApp.Models
{
    public class JournalEntry
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        public string Title { get; set; } = string.Empty;

        [DataType(DataType.MultilineText)]
        public string Content { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        // Mood tracking
        public string? Mood { get; set; }

        // Tags for categorization
        public string? Tags { get; set; }

        // Weather (optional)
        public string? Weather { get; set; }

        // Location (optional)
        public string? Location { get; set; }


        // Helper method to get tags as list
        public List<string> GetTagsList()
        {
            if (string.IsNullOrEmpty(Tags))
                return new List<string>();
            
            return Tags.Split(',', StringSplitOptions.RemoveEmptyEntries)
                      .Select(tag => tag.Trim())
                      .ToList();
        }

        // Helper method to set tags from list
        public void SetTagsList(List<string> tags)
        {
            Tags = string.Join(", ", tags);
        }
    }
}
