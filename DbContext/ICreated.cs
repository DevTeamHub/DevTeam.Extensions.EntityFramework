using System;

namespace DevTeam.EntityFrameworkExtensions.DbContext
{
    public interface ICreated
    {
        int CreatedBy { get; set; }

        DateTime CreatedOn { get; set; }
    }
}
