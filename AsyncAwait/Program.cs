var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("data", async (ILogger<Program> logger) =>
{
    logger.LogInformation("данные отправились");
    
    await Task.Delay(5000);
    
    logger.LogInformation("данные получили обратно");

    return "Наши данные";
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();