using System.Collections.Generic;

namespace TradeDash.BackgroundTasks.Abstractions
{
    public interface IDataRefreshService
    {
        List<string> GetExampleDataList();
    }
}