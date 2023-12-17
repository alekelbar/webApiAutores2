using Microsoft.EntityFrameworkCore;
using webApi.Database;

namespace webApi
{
    public class StartUp(IConfiguration Configuration)
    {
        private readonly IConfiguration Configuration = Configuration;

        public void ConfigureServices(IServiceCollection Services)
        {
            // Servicio de base de datos...
            var connectionString = Configuration.GetConnectionString("mysql");
            Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            );

            Services.AddEndpointsApiExplorer();
            Services.AddSwaggerGen();
            Services.AddControllers();
        }

        public void Configure(IWebHostEnvironment env, IApplicationBuilder app)
        {

            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(options =>
            {
                options.MapControllers();
            });
        }
    }
}