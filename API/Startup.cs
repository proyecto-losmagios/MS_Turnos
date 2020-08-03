using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using AccessData;
using AccessData.Commands;
using Domain.Commands;
using Domain.Queries;
using AccessData.Queries;
using Application.Services;
using System.Data;
using SqlKata.Compilers;


namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {

            services.AddCors(c =>  {  
                c.AddPolicy("AllowOrigin", options => options
                                                            .AllowAnyOrigin()
                                                            .AllowAnyMethod()
                                                            .AllowAnyHeader());
            });

            services.AddControllers();
            
            var connectionString = Configuration.GetSection("ConnectionString").Value;

            // EF Core
            services.AddDbContext<APIDbContext>(options => options.UseNpgsql(connectionString));

            // SQLKATA
            services.AddTransient<Compiler, PostgresCompiler>();
            services.AddTransient<IDbConnection>(b => {
                return new Npgsql.NpgsqlConnection(connectionString);
            });
            
            services.AddTransient<IGenericsRepository, GenericsRepository>();
            services.AddTransient<ITurnoServices, TurnoServices>();
            services.AddTransient<ITurnoQuery, TurnoQuery>();
            services.AddTransient<IAgendaServices, AgendaServices>();
            services.AddTransient<IAgendaQuery, AgendaQuery>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env){
            app.UseCors(options => options.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
