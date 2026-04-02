using EventManager.Interfaces;
using EventManager.Services;
using EventManager.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddSingleton<IEventRepository, EventRepository>();
builder.Services.AddScoped<IEventService, EventService>();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();
