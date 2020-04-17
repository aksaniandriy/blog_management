using System.ComponentModel.DataAnnotations;

namespace Blog.Api.Models
{
    public class CreateCommentRequest
    {
        [Required]
        [MaxLength(1000)]
        public string Text { get; set; }
    }
}
