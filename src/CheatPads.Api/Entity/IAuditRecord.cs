using System;

namespace CheatPads.Api.Entity
{
    public interface IAuditRecord
    {     
        DateTime Created { get; set; }

        DateTime Updated { get; set; }
    }
}
