using System;

namespace DevTeam.Extensions.EntityFramework;

public interface ICreated<TKey>
{
    TKey CreatedBy { get; set; }
    DateTime CreatedOn { get; set; }
}

public interface ICreated : ICreated<int>
{ }
