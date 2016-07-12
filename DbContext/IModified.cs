using System;

namespace DevTeam.EntityFrameworkExtensions.DbContext
{
    public interface IModified
    {
        int ModifiedBy { get; set; }

        DateTime ModifiedOn { get; set; }
    }
}
