namespace webApi
{
    public class StartUp(IConfiguration Configuration)
    {
        private readonly IConfiguration configuration = Configuration;

        public void ConfigureServices(IServiceCollection Services)
        {
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

            app.UseEndpoints(options => {
                options.MapControllers();
            });
        }
    }
}