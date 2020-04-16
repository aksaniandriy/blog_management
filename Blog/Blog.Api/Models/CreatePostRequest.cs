using System.ComponentModel.DataAnnotations;

namespace Blog.Api.Models
{
    public class CreatePostRequest
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }
    }
}
