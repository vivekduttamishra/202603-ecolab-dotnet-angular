using SimpleWeb.Utils;
using System.Text;

namespace SimpleWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            var visits = new Dictionary<string, int>(); //string -> url, int -> visits

            app.UseOnUrl("/admin/stats", async context =>
            {
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

                foreach (var stat in visits)
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

                if (visits.ContainsKey(path))
                    visits[path]++;
                else
                    visits[path] = 1;
            });


           

            app.UseOnUrl("/", async context =>
            {
                


                return $"<h1>Welcome to Book's Club</h1>";
            });

            app.UseOnUrl("/authors", async context =>
            {
               


                return $"<h1>List of All Authors</h1>";
            });

            app.UseOnUrl("/authors", async context =>
            {
                


                var parts = context.Request.Path.ToString().Split('/');
                var id = parts[parts.Length - 1];
                return $"<h1>About {id}</h1>";
            }, PathMatcher.StartsWith);


            app.UseOnUrl("/books", async context =>
            {

               

                return $"<h1>Welcome to Book's Club</h1>";
            });

            app.UseOnUrl("/books", async context =>
            {
               
                var parts = context.Request.Path.ToString().Split('/');
                var id = parts[parts.Length - 1];
                return $"<h1>About The Book {id} </h1>";
            }, PathMatcher.StartsWith);

            

            app.Run();
        }

        private static void RedundantStatsLogic(WebApplication app, Dictionary<string, int> visits)
        {
            app.UseOnUrl("/", async context =>
            {
                var path = context.Request.Path.ToString().ToLower();

                if (visits.ContainsKey(path))
                    visits[path]++;
                else
                    visits[path] = 1;


                return $"<h1>Welcome to Book's Club</h1>";
            });

            app.UseOnUrl("/authors", async context =>
            {
                var path = context.Request.Path.ToString().ToLower();

                if (visits.ContainsKey(path))
                    visits[path]++;
                else
                    visits[path] = 1;


                return $"<h1>List of All Authors</h1>";
            });

            app.UseOnUrl("/authors", async context =>
            {
                var path = context.Request.Path.ToString().ToLower();

                if (visits.ContainsKey(path))
                    visits[path]++;
                else
                    visits[path] = 1;


                var parts = context.Request.Path.ToString().Split('/');
                var id = parts[parts.Length - 1];
                return $"<h1>About {id}</h1>";
            }, PathMatcher.StartsWith);


            app.UseOnUrl("/books", async context =>
            {

                var path = context.Request.Path.ToString().ToLower();

                if (visits.ContainsKey(path))
                    visits[path]++;
                else
                    visits[path] = 1;

                return $"<h1>Welcome to Book's Club</h1>";
            });

            app.UseOnUrl("/books", async context =>
            {
                var path = context.Request.Path.ToString().ToLower();

                if (visits.ContainsKey(path))
                    visits[path]++;
                else
                    visits[path] = 1;


                var parts = context.Request.Path.ToString().Split('/');
                var id = parts[parts.Length - 1];
                return $"<h1>About The Book {id} </h1>";
            }, PathMatcher.StartsWith);
        }

    }

   
}
