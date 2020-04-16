using Blog.Database.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Database.Configuration
{
    internal static class PostConfiguration
    {
        internal static void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Comments)
                .WithOne(c => c.Post)
                .HasForeignKey(c => c.PostId);

            builder
                .Property(x => x.Title)
                .HasMaxLength(150);

            builder
                .Property(x => x.Text)
                .HasMaxLength(10000);
        }
    }
}
