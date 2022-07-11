var builder = WebApplication.CreateBuilder(args);

//  Add Services
builder.Services.AddControllers();

var app = builder.Build();

//Register Middleware

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
