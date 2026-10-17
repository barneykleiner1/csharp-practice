var builder = WebApplication.CreateBuilder(args);

// Добавляем поддержку контроллеров
builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

// Включаем маршрутизацию для контроллеров
app.MapControllers();

app.Run();