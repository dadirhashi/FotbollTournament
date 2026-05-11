using FotbollTournament.Application;
using FotbollTournament.Infrastructure;

namespace FotbollTournament;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Layer registrations — everything else hides inside these
        builder.Services.AddApplication();
        builder.Services.AddInfrastructure(builder.Configuration);

        // API-level
        builder.Services.AddControllers();
        builder.Services.AddCors();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddOpenApi();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/openapi/v1.json", "Fotboll Tournament API V1");
                options.RoutePrefix = "swagger";
            });
        }

        app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
