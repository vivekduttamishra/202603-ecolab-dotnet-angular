using System.Text;
using SimpleWeb.Utils;

namespace ConceptArchitect.Stats.RequestLogger;

public class RequestLoggerService
{
    Dictionary<string, int> stats = new Dictionary<string, int>();

    public async Task AddStatsAsync(string path)
    {
        path = path.ToLower();
        if (stats.ContainsKey(path))
            stats[path]++;
        else
            stats[path] = 1;
    }

    public async Task<Dictionary<string, int>> GetStats()
    {
        return stats;
    }

    public async Task<int> GetStats(string path)
    {
        if (stats.ContainsKey(path))
            return stats[path];
        else
            return 0;
    }
}


public static class RequestLoggerExtensions
{
    public static WebApplication UseRequestLogger(this WebApplication app)
    {

         app.UseOnUrl("/admin/stats", async context =>
          {
              //var loggerService = new RequestLoggerService();
              var loggerService = context.RequestServices.GetService<RequestLoggerService>();

              var str = new StringBuilder("""
                    <h1>Visit Stats</h1>
                    <table style="width:80%;border:1px solid gray;text-align:center">
                        <thead>
                            <tr>
                                <th>Url</th>
                                <th>Visits</th>
                            </tr>
                        </thead>
                        <tbody>
                    """);

              var stats = await loggerService.GetStats();
              foreach (var stat in stats)
              {
                  str.Append($"""
                        <tr>
                            <td>{stat.Key}</td>
                            <td>{stat.Value}</td>
                        </tr>
                        """);
              }

              str.Append("</tbody></table>");

              return str.ToString();


          });

            

        app.UseBefore(async context =>
            {
                var path = context.Request.Path.ToString().ToLower();
                //var requestLoggerService = new RequestLoggerService();
                var requestLoggerService = app.Services.GetService<RequestLoggerService>();

                await requestLoggerService.AddStatsAsync(path);

            });


       
        return app;
    }

    public static void AddLoggerService(this IServiceCollection service)
    {
        service.AddSingleton<RequestLoggerService>();
    }

}

