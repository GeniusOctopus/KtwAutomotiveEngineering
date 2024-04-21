using Asp.Versioning;
using Asp.Versioning.Conventions;
using KtwAutomotiveEngineering.DataAccess;
using KtwAutomotiveEngineering.Extensions;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Core;

namespace KtwAutomotiveEngineering
{
    class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog((ctx, logBuilder) =>
            {
                logBuilder
                    .Enrich.WithProperty("Environment", ctx.HostingEnvironment.EnvironmentName)
                    .Enrich.WithProperty("Application", ctx.HostingEnvironment.ApplicationName)
                    .Enrich.FromLogContext();

                if (ctx.HostingEnvironment.IsDevelopment())
                {
                    logBuilder.WriteTo.Console();
                    logBuilder.WriteTo.Debug();
                }
                else
                {
                    var seq = ctx.Configuration.GetSection("Seq");
                    var levelSwitch = new LoggingLevelSwitch(Serilog.Events.LogEventLevel.Verbose);
                    logBuilder.WriteTo.Seq(seq["ServerUrl"]!,
                        apiKey: seq["ApiKey"],
                        controlLevelSwitch: levelSwitch);
                }
            });

            builder.Services.AddControllers();

            builder.Services
                .AddApiVersioning(options =>
                {
                    options.ReportApiVersions = true;
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    options.DefaultApiVersion = new ApiVersion(1, 0);
                })
                .AddApiExplorer(options =>
                {
                    options.GroupNameFormat = "VVV";
                    options.SubstituteApiVersionInUrl = true;
                    options.AssumeDefaultVersionWhenUnspecified = true;
                })
                .AddMvc(options =>
                {
                    options.Conventions.Add(new VersionByNamespaceConvention());
                });

            builder.Services.AddDbContext<RepositoryContext>(options =>
            {
                var connectionString = builder.Configuration.GetConnectionString("SqlConnection");
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), b => b.MigrationsAssembly(nameof(KtwAutomotiveEngineering)));
            });

            builder.Services.AddOpenApiDocument();
            builder.Services.AddAuthentication();
            builder.Services.ConfigureServiceManager();
            builder.Services.ConfigureIdentity();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseOpenApi();
            app.UseSwaggerUi(ui =>
            {
                ui.EnableTryItOut = true;
                ui.SwaggerRoutes.Add(new("v1", "/swagger/v1/swagger.json"));
            });

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}