using Blog.Database.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Database.Configuration
{
    internal static class CommentConfiguration
    {
        internal static void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId);

            builder.Property(x => x.Text)
                .HasMaxLength(1000);
        }
    }
}
