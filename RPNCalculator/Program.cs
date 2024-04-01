
using Asp.Versioning;
using Microsoft.OpenApi.Models;
using RPN.Application;
using RPN.Application.Interfaces;
using RPN.Application.RpnStackLogics;
using RPN.Application.Strategy;
using RPNCalculator.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiVersioning(o =>
                {
                    o.AssumeDefaultVersionWhenUnspecified = true;
                    o.DefaultApiVersion = new ApiVersion(1, 0);
                    o.ReportApiVersions = true;
                }).AddApiExplorer(options =>
                {
                    options.GroupNameFormat = "'v'VVV";
                    options.SubstituteApiVersionInUrl = true;
                    options.AssumeDefaultVersionWhenUnspecified = true;
                });
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IOperationFactory, OperationFactory>();
builder.Services.AddSingleton<IOperationStrategy, AdditionStrategy>();
builder.Services.AddSingleton<IOperationStrategy, DivisionStrategy>();
builder.Services.AddSingleton<IOperationStrategy, MultiplicationStrategy>();
builder.Services.AddSingleton<IOperationStrategy, SubtractionStrategy>();

builder.Services.AddScoped<IOperationService, OperationService>();
builder.Services.AddSingleton<IRpnStackLogics, RpnStackLogics>(); 
builder.Services.AddScoped<IStackService, StackService>();


//Swagger Documentation Section
var info = new OpenApiInfo()
{
    Title = "RPN Calculator",
    Version = "v1",
    Description = "Basic operation for an RPN Calculator",
    Contact = new OpenApiContact()
    {
        Name = "Mehdi SASSI",
        Email = "sassi.mehdy@gmail.com",
    }

};

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", info);

    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
