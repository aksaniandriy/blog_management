using System.ComponentModel.DataAnnotations;

namespace Blog.Api.Models
{
    public class CreatePostRequest
    {
        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        [Required]
        [MaxLength(10000)]
        public string Text { get; set; }
    }
}
