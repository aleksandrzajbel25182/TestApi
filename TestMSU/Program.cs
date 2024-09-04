using Microsoft.EntityFrameworkCore;
using TestMSU.database;
using TestMSU.repository;
using TestMSU.service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<MessageContext>(options =>
    options.UseNpgsql("Host=db;Port=5432;Database=messageDb;Username=root;Password=password"));

builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
