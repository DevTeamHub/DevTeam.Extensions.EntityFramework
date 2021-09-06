using System;

namespace DevTeam.EntityFrameworkExtensions
{
    public interface IModified<TKey>
    {
        TKey ModifiedBy { get; set; }
        DateTime ModifiedOn { get; set; }
    }

    public interface IModified: IModified<int> 
    { }
}
