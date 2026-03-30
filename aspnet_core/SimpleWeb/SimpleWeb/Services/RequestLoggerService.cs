namespace ConceptArchitect.Stats.RequestLogger;

public class RequestLoggerService
{
    Dictionary<string,int> stats=new Dictionary<string, int>();

    public async Task AddStatsAsync(string path)
    {
        path=path.ToLower();
        if(stats.ContainsKey(path))
            stats[path]++;
        else
            stats[path]=1;
    }

    public async Task<Dictionary<string, int>> GetStats()
    {
        return stats;
    }

    public async Task<int> GetStats(string path)
    {
        if(stats.ContainsKey(path))
            return stats[path];
        else
            return 0;
    }
}




