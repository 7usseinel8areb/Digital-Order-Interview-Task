using DigitalOrder.Application;
using DigitalOrder.Application.Middlewares;
using DigitalOrder.Infrastructure;
using DigitalOrder.Infrastructure.Data;
using DigitalOrder.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("remoteDb");
//var connectionString = builder.Configuration.GetConnectionString("con");
var _logger = builder.Services.BuildServiceProvider().GetRequiredService<ILogger<Program>>();

#region Dependency Injection
// Add services to the container.
builder.Services
    .AddInfrastructure()
    .AddApplication()
    .AddService()
    .AddServiceRegistration(builder.Configuration);
#endregion

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

#region Swagger Configuration
// Configure Swagger with Bearer Token Support
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "DigitalOrder API",
        Version = "v1",
        Description = "API documentation for DigitalOrder with Bearer Token Authentication",
    });

    // Add Bearer Token Authentication
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' followed by your token in the text input below.\nExample: 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...'"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});
#endregion

#region Connection String
// Configure the database context
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});
#endregion

#region CORS
var CORS = "AllowAll";
builder.Services.AddCors(options =>
{
    options.AddPolicy(CORS, policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "DigitalOrder API v1");
});


app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseCors(CORS);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();