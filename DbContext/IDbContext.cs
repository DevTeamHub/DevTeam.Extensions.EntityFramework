using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace DevTeam.EntityFrameworkExtensions.DbContext
{
    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>()
            where TEntity: class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class;

        Database Database { get; }

        DbChangeTracker ChangeTracker { get; }

        int SaveChanges();
    }
}
