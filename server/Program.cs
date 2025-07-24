
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using server.Data;
using server.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Configuration : JWT key
var jwtKey = builder.Configuration["Jwt:Key"] ?? throw new Exception("JWT key not configured");

// 2. Add services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowClient", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Database + Dependency Injection
builder.Services.AddDatabaseServices(builder.Configuration);
builder.Services.AddScoped<IAuthService, AuthService>();

// Authentification JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
        };
    });

builder.Services.AddAuthorization();

// Ajout support Controllers & Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 3. Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowClient");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers(); // <-- active les controllers REST

// Endpoint de test
app.MapGet("/api/status", () => new { Status = true });

// 4. Initialisation de la base de données
using (var scope = app.Services.CreateScope())
{
    try
    {
        DbSeeder.Initialize(scope.ServiceProvider);
        Console.WriteLine("Database initialized successfully");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error during DB initialization: {ex.Message}");
        throw;
    }
}

app.Run();
