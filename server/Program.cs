var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowClient", policy =>
  {
    policy.WithOrigins("http://localhost:4200")
      .AllowAnyHeader()
      .AllowAnyMethod();

  });
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment()) {
  app.UseDeveloperExceptionPage();
}

app.UseCors("AllowClient");
app.UseHttpsRedirection();

// Basic API endpoint
app.MapGet("/api/status", () => new { Status = true });

app.Run();
