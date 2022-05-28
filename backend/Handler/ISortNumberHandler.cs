using backend.Queries;
using backend.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Handler
{
    public interface ISortNumberHandler
    {
        ActualSortResult SortNumber(GetStringNumber request);
        //void SaveHistory(ActualSortResult actualSortResult);
        IEnumerable<ActualSortResult> GetHistory();
    }
}
