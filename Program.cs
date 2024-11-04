using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configuración de Serilog con tres Sinks y diferentes niveles de registro.
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console(restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Debug)  // Console Sink
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day, restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information)  // File Sink
    .WriteTo.SQLite("logs/logs.db", restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Error)  // SQLite Sink
    .CreateLogger();

builder.Host.UseSerilog(); // Usar Serilog como el proveedor de logs para la aplicación

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ANDISBANK API v1");
    c.RoutePrefix = string.Empty; // Acceder a Swagger en `http://localhost:5000`
});


app.MapControllers();

// Cerrar el logger de Serilog correctamente al terminar la aplicación
app.Run();
Log.CloseAndFlush();
