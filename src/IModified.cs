using System;

namespace DevTeam.Extensions.EntityFramework;

public interface IModified<TKey>
{
    TKey ModifiedBy { get; set; }
    DateTime ModifiedOn { get; set; }
}

public interface IModified : IModified<int>
{ }
