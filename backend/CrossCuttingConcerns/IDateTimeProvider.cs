using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.CrossCuttingConcerns
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
        DateTime UtcNow { get; }

        DateTimeOffset OffsetNow { get; }

        DateTimeOffset OffsetUtcNow { get; }
    }



}
