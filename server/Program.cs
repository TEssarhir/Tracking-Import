
using server.Data;
using server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddCorsPolicy(builder.Configuration);
builder.Services.AddDatabaseServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment()) {
    app.UseDeveloperExceptionPage();
}

app.UseCors("AllowClient");
app.UseHttpsRedirection();

// Basic API endpoint
app.MapGet("/api/status", () => new { Status = true });

// Initialize the database
using (var scope = app.Services.CreateScope())
{
    try
    {
        // Use the static DbSeeder class
        DbSeeder.Initialize(scope.ServiceProvider);
        Console.WriteLine("Database initialized successfully");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred while initializing the database: {ex.Message}");
        throw;
    }
}

app.Run();
