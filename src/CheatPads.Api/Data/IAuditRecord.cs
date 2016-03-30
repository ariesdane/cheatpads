using System;

namespace CheatPads.Api.Data
{
    public interface IAuditRecord
    {     
        DateTime Created { get; set; }

        DateTime Updated { get; set; }
    }
}
