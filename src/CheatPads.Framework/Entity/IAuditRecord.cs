using System;

namespace CheatPads.Framework.Entity
{
    public interface IAuditRecord
    {     
        DateTime Created { get; set; }

        DateTime Updated { get; set; }
    }
}
