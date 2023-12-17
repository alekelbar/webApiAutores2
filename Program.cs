using webApi;

var builder = WebApplication.CreateBuilder(args);

var startUp = new StartUp(builder.Configuration);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
startUp.ConfigureServices(builder.Services);

var app = builder.Build();

startUp.Configure(app.Environment, app);

app.Run();
