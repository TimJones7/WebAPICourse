
var builder = WebApplication.CreateBuilder(args);

//  Add Services/dependencies
builder.Services.AddControllers();

var app = builder.Build();

//Register Middleware

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
