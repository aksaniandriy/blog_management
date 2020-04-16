using System;

namespace Blog.Services.Models
{
    public class PostDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }
    }
}
