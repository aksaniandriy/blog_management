using System;

namespace Blog.Database.Entities
{
    public class Comment : IDateTrack
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedUtc { get; set; }

        public Guid PostId { get; set; }

        public Post Post { get; set; }
    }
}
