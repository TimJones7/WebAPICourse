
using DataStore.EF;
using Microsoft.EntityFrameworkCore;




var builder = WebApplication.CreateBuilder(args);


//  Add Services/dependencies


builder.Services.AddControllers();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<BugsContext>(options =>
    {
        options.UseInMemoryDatabase("Bugs");
    });
}

builder.Services.AddSwaggerGen();

var app = builder.Build();

//Register Middleware

app.UseRouting();


if( app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    //  Create the in-memory Database
    
}
app.UseSwagger();
app.UseSwaggerUI();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
