
using ConceptArchitect.Banking;
using ConceptArchitect.Banking.EFRepository;
using ConceptArchitect.Utils;
using ConceptArchitect.Utils.Web;
using Microsoft.EntityFrameworkCore;
using ConceptArchitect.ApiKeyService;

namespace BankingApiServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder);

            var app = builder.Build();

            ConfigureMiddlewares(app);

            app.Run();
        }

        private static void ConfigureServices(WebApplicationBuilder builder)
        {
            // Add services to the container.

            builder.Services.AddControllers(config =>
            {
                config.Filters.Add(new InvalidIdMapperAttribute());
            } );

            builder.Services.AddDbContext<BankingContext>(option =>
            {
                var connectionString = builder.Configuration.GetConnectionString("BankingContext");
                option.UseSqlServer(connectionString);
            });

            builder.Services.AddScoped<IRepository<Customer, String>, EFCustomerRepository>();
            builder.Services.AddScoped<CustomerService>();
            builder.Services.AddSingleton<IApiKeyService, DummyApiKeyService>();
            builder.Services.AddCors(config =>
            {
                config.AddPolicy("AllowAll",
                    policy =>
                    {
                        policy
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowAnyOrigin();
                    });
            });

            
            //builder.Services.AddOpenApi();
        }

        private static void ConfigureMiddlewares(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.MapOpenApi();
            //}


            // app.UseExceptionHandler<InvalidIdException>(404, ex=>new
            // {
            //     Message=ex.Message,
            //     Id= ex.Id
            // });

            //app.UseAuthorization();


            //app.UseHttpsRedirection();
            app.UseRouting();
            
            app.UseCors("AllowAll");

            app.UseFileServer();

            Console.WriteLine("CORS SETUP");
            app.MapControllers();
            
            
            
            //app.UseCors(policy =>
            //{
            //    policy.AllowAnyHeader();
            //    policy.AllowAnyMethod();
            //    policy.AllowAnyOrigin();
            //});

            //app.UseBefore(async context =>
            //{
            //    context.Response.Headers["Access-Control-Allow-Origin"] = "*";
            //    context.Response.Headers["Access-Control-Allow-Methods"] = "*";
            //});
        }

       
    }
}
