using System;

namespace Blog.Api.Models
{
    public class BlogPost
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public DateTime PostDate { get; set; }
    }
}
