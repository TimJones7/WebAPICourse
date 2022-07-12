using PlatformDemo.Filters;

var builder = WebApplication.CreateBuilder(args);

//  Add Services/dependencies
builder.Services.AddControllers(options => 
{
    options.Filters.Add<Version1DiscontinueResourceFilter>();
});

var app = builder.Build();

//Register Middleware

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
