using iTodo.API.Extensions;
using iTodo.Application;
using iTodo.Persistence;
using iTodo.Persistence.Context;
using Microsoft.OpenApi.Models;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);

    #region Configure Serilog

    Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .Enrich.FromLogContext()
        .CreateLogger();

    builder.Host.UseSerilog(Log.Logger);

    #endregion

    #region Add services to the container.

    builder.Services.ConfigurePersistence(builder.Configuration);
    builder.Services.ConfigureApplication();

    builder.Services.ConfigureApiBehavior();
    builder.Services.ConfigureCorsPolicy();

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        var fileName = "iTodo.API" + ".XML";
        var filePath = Path.Combine(baseDirectory, fileName);
        
        c.IncludeXmlComments(filePath);
        c.SwaggerDoc("v1", 
            new OpenApiInfo {Version = "v1", Title = "iTodo.API", Description = "iTodo Web API Project"});
    });

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
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception occurred while running the application");
}
finally
{
    Log.Information("Shut down application complete");
    Log.CloseAndFlush();
}