using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using TodoApi.Context;

namespace TodoApi
{
    public class Startup
    {
        readonly string AllowMyWebApp = "_allowMyWebApp";

        public IConfiguration Configuration { get; }

        public Startup (IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services)
        {
            services.AddCors (options =>
            {
                options.AddPolicy (AllowMyWebApp,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:5500","http:127.0.0.1:5500");
                    });
            });
            services.AddDbContext<TodoContext> (opt => opt.UseInMemoryDatabase ("TodoList"));
            services.AddSingleton<IRomanoContext, RomanoContext> ();
            services.AddControllers ();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment ())
            {
                app.UseDeveloperExceptionPage ();
            }

            app.UseCors(AllowMyWebApp);

            app.UseHttpsRedirection ();

            app.UseRouting ();

            app.UseAuthorization();

            app.UseEndpoints (endpoints =>
            {
                endpoints.MapControllers ();
            });
        }
    }
}