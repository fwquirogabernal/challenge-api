using Challenge.CommandsAndQueries.Queries;
using Challenge.DataBase.Setup;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Challenge.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            InitiallDbContext(services);
            IntallCommandsAndQueries(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void InitiallDbContext(IServiceCollection services)
        {
            services.AddDbContext<IDataBaseContext, DataBaseContext>(
                options => options.UseSqlServer("Server=.;Database=Challenge;Trusted_Connection=True;"));
        }

        private static void IntallCommandsAndQueries(IServiceCollection services)
        {
            services.AddScoped<ITaskQuery, TasksQueries>();
        }
    }
}
