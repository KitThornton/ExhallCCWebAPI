using System;
using System.IO;
using System.Reflection;
using ExhallCCWebAPI.DataAccess;
using ExhallCCWebAPI.DataAccess.Batting;
using ExhallCCWebAPI.DataAccess.Players;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace ExhallCCWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // SslMode=Require;TrustServerCertificate=true;
            var conString = new NpgsqlConnection(Configuration.GetConnectionString("LocalhostConnection"));
            
            services.AddDbContext<PlayerContext>(options => options.UseNpgsql(conString));
            
            services.AddScoped<IPlayerDataAccessProvider, PlayerDataAccessProvider>();
            services.AddScoped<IBattingDataAccessProvider, BattingDataAccessProvider>();

            services.AddSwaggerGen(
                options =>
                {
                    // Allow XML comments defined above each method to be displayed on swagger UI
                    // var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    // options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));
                }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}