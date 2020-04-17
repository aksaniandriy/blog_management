using System;

namespace Blog.Services.Models
{
    public class CommentDto
    {
        public CommentDto()
        {
        }

        public CommentDto(string text)
        {
            Text = text;
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedUtc { get; set; }
    }
}
