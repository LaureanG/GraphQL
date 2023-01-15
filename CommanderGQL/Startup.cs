using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using CommanderGQL.Data;
using CommanderGQL.GraphQL;
using GraphQL.Server.Ui.Voyager;
using CommanderGQL.GraphQL.Platforms;
using CommanderGQL.GraphQL.Commands;

namespace CommanderGQL
{
    public class Startup
    {
        private readonly IConfiguration Configuration;
       
        public Startup(IConfiguration configuration){
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services){
            //services.AddRazorPages();
            services.AddPooledDbContextFactory<AppDbContext>(opt => opt.UseSqlServer
            (Configuration.GetConnectionString("DBConnectionString")));
            services
            .AddGraphQLServer()
            .AddQueryType<Query>()
            .AddType<PlatformType>()
            .AddType<CommandType>()
            .AddProjections();
        }

        public void Configure(WebApplication app, IWebHostEnvironment env){
            // app.UseHttpsRedirection();
            // app.UseStaticFiles();
            app.UseRouting();
            // app.UseAuthorization();
            //app.MapRazorPages();
            //app.MapGet("/", () => "Hello World!");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
            
            app.UseGraphQLVoyager("/graphql-voyager",new VoyagerOptions()
            {
                GraphQLEndPoint = "/graphql"
            });
            app.Run();
        }
    }
}