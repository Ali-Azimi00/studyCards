using Microsoft.EntityFrameworkCore;
using CardsAPI.Data;
using CardsAPI.Infrastructure.RepositoryInterface;
using CardsAPI.Infrastructure.DataRepository;
using CardsAPI.Services.ServiceInterface;
using CardsAPI.Services.Data;
using CardsAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CardsAPIContext>(
               options => options.UseSqlServer(builder.Configuration.GetConnectionString("StudyCardsConnection")));

builder.Services.AddTransient<ISCardsRepo, SCardsRepo>();
builder.Services.AddTransient<ISCardsService, SCardsService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();



app.UseHttpsRedirection();

app.UseCors("AllowAngularApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
