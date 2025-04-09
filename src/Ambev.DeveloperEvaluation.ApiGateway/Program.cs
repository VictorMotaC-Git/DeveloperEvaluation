using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Configura ocelot.json
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

// Adiciona Ocelot
builder.Services.AddOcelot(builder.Configuration);

// (Opcional) CORS – útil em dev/local
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// (Opcional) CORS
app.UseCors("AllowAll");

// Middleware Ocelot
await app.UseOcelot();

// Inicia app
app.Run();
