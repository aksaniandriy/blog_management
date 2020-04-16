using System;
using System.Collections.Generic;

namespace Blog.Database.Entities
{
    public class Post : IDateTrack
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public DateTime CreatedUtc { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
