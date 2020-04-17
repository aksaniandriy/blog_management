using System;
using System.Collections.Generic;

namespace Blog.Services.Models
{
    public class PostDto
    {
        public PostDto() { }

        public PostDto(string title, string text)
        {
            Title = title;
            Text = text;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime CreatedUtc { get; set; }
        public IEnumerable<CommentDto> Comments { get; set; }
    }
}
