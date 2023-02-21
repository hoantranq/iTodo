using iTodo.API.Extensions;
using iTodo.Application;
using iTodo.Persistence;
using iTodo.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

#region Add services to the container.
builder.Services.ConfigurePersistence(builder.Configuration);
builder.Services.ConfigureApplication();

builder.Services.ConfigureApiBehavior();
builder.Services.ConfigureCorsPolicy();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

var app = builder.Build();
var serviceScope = app.Services.CreateScope();
var dataContext = serviceScope.ServiceProvider.GetService<AppDbContext>();

dataContext?.Database.EnsureCreated();

#region Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseErrorHandler();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
#endregion
