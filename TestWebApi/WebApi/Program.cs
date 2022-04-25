using Repository.GameRepository;
using Service.GameService;
using ViewModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

List<GameViewModel> games = new List<GameViewModel>();

app.MapGet("/api/games/{id}", (long id) =>
{
    GameViewModel? game = games.FirstOrDefault(g => g.Id == id);
    if (game == null) return Results.NotFound();
    return Results.Json(game);
}); 

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();