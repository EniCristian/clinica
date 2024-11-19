using Clinica;
using Clinica.Application.Common.Extensions;
using Clinica.EndpointDefinitions;
using Clinica.Infrastructure;
using Clinica.Infrastructure.Persistence;
using Clinica.Middlewares;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
string[] allowedOrigins = (builder.Configuration.GetSection("CorsSettings:AllowUrls").AsEnumerable().Where(p => !string.IsNullOrWhiteSpace(p.Value)).Select(p => p.Value)?.ToArray()?? Array.Empty<string>())!;


builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApiServices();

var app = builder.Build();
const string baseRoute = "/api";
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(c =>
    {
        c.RouteTemplate = "swagger/{documentName}/swagger.json";
        c.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
        {
            swaggerDoc.Servers = new List<OpenApiServer> { new() { Url = $"{httpReq.Scheme}://{httpReq.Host.Value}{baseRoute}" } };
        });
    });
    app.UseSwaggerUI();
    using var scope = app.Services.CreateScope();
    var initializer = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitializer>();
    await initializer.InitialiseAsync();
    await initializer.SeedAsync();
}
app.UsePathBase(new PathString(baseRoute));
app.UseHttpsRedirection();
app.AddEndpoints();
app.UseExceptionHandling();
app.UseLocalization();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.UseCors(x => x
    .WithOrigins(allowedOrigins)
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials()
    .WithExposedHeaders("content-disposition"));
app.Run();

