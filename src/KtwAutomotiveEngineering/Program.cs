using Asp.Versioning;
using Asp.Versioning.Conventions;

namespace KtwAutomotiveEngineering
{
    class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

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

            builder.Services.AddOpenApiDocument();

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