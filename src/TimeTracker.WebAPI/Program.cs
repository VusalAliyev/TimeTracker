using TimeTracker.Infrastructure;
using TimeTracker.Application;
using TimeTracker.Application.Common;
using TimeTracker.WebAPI.Services;
using Hangfire;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddScoped<IReminderBy, ReminderBy>();
builder.Services.AddHangfire(config =>
        config.UseSqlServerStorage("Server=localhost;Database=HangfireDb;Trusted_Connection=true;TrustServerCertificate=true;"));
builder.Services.AddHangfireServer();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHangfireDashboard();
app.UseHangfireServer();
app.UseAuthorization();

app.MapControllers();


app.Run();
