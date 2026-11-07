var builder = WebApplication.CreateBuilder(args);

// Services registreren.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger beschikbaar maken tijdens het ontwikkelen.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// De routes uit de controllers beschikbaar maken.
app.MapControllers();

app.Run();