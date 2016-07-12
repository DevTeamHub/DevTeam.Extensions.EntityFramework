
namespace DevTeam.EntityFrameworkExtensions.DbContext
{
    public interface IEntityInfo
    {
        int EntityId { get; set; }
        int EntityTypeId { get; set; }
    }
}
