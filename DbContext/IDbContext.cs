using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DevTeam.EntityFrameworkExtensions.DbContext
{
    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>()
            where TEntity: class;
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
