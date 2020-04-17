using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Database.Database
{
    public abstract class DbContextBase<T> : DbContext where T: DbContext
    {
        public DbContextBase(DbContextOptions<T> options): base(options) { }
        /// <inheritdoc />
        /// <summary>
        /// Automatically set 'Created' prop
        /// </summary>
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            SetCreatedUtcProperty();

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        /// <inheritdoc />
        /// <summary>
        /// Automatically set 'Created' prop
        /// </summary>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            SetCreatedUtcProperty();

            return base.SaveChangesAsync(cancellationToken);
        }

        /// <inheritdoc />
        /// <summary>
        /// Automatically set 'Created' prop
        /// </summary>
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            SetCreatedUtcProperty();

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        /// <inheritdoc />
        /// <summary>
        /// Automatically set 'Created' prop
        /// </summary>
        public override int SaveChanges()
        {
            SetCreatedUtcProperty();

            return base.SaveChanges();
        }

        private void SetCreatedUtcProperty()
        {
            ChangeTracker.DetectChanges();

            foreach (var entry in ChangeTracker.Entries().Where(x => x.State == EntityState.Added))
            {
                if (entry.Members.Any(x => x.Metadata.Name == nameof(IDateTrack.CreatedUtc)))
                {
                    var addedEntity = entry.Member(nameof(IDateTrack.CreatedUtc));
                    if (addedEntity != null)
                    {
                        addedEntity.CurrentValue = DateTime.UtcNow;
                    }
                }
            }
        }
    }
}
