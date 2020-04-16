using System;

namespace Blog.Api.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }
    }
}
