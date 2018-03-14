using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogManager.Models
{
    public class Blog
    {
        public int Id { get; set; }
        [Required]
        [StringLength(64, MinimumLength = 5)]
        public string Title { get; set; }
        [Required]
        [StringLength(350, MinimumLength = 5)]
        public string Summary { get; set; }
        [Required]
        [StringLength(3500, MinimumLength = 5)]
        public string Content { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
