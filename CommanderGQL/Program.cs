using CommanderGQL;

var builder = WebApplication.CreateBuilder(args);
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services); // calling ConfigureServices method
//In .NET6, Configure services to be added to the container here
var app = builder.Build();
startup.Configure(app, builder.Environment); // calling Configure method
//In .NET6, Configure middleware/ HTTP request pipeline here
// app.MapGet("/", () => "Hello World!");
// app.Run();
