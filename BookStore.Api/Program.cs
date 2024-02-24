using System.Net;
using BookStore.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddLogging( config => {
    config.AddConsole();
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler(configure => {
        configure.Run(
            async context => 
            {
                context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync("An unexpected problem happend.");
            });
    });
}

app.UseHttpsRedirection();
app.RegisterBooksEndpoints();

app.Run();
