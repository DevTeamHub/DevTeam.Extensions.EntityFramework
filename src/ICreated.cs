using System;

namespace DevTeam.EntityFrameworkExtensions
{
    public interface ICreated<TKey>
    {
        TKey CreatedBy { get; set; }
        DateTime CreatedOn { get; set; }
    }

    public interface ICreated: ICreated<int>
    { }
}
