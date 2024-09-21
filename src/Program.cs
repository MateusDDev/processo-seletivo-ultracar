using Ultracar.Database;
using Ultracar.Repositories;
using Ultracar.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<UltracarContext>();
builder.Services.AddControllers();
builder.Services.AddScoped<IPartBudgetRepository, PartBudgetRepository>();
builder.Services.AddScoped<IPartRepository, PartRepository>();

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

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

