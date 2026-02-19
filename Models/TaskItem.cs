using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace project
{
    public class TaskItem
    {
        public int Id { get; set; }
        [Required] 
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty();
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}