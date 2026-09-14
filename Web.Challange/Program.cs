using Application.Service.Challenge.Interfaces;
using Application.Service.Challenge.Services; // namespace do seu serviço
using AutoMapper;
using Domain.Challenge.Interface;
using Infra.Challenge.Data;
using Infra.Challenge.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var key = builder.Configuration["Jwt:Key"]; // chave secreta no appsettings.json
var issuer = builder.Configuration["Jwt:Issuer"];
var audience = builder.Configuration["Jwt:Audience"];

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = issuer,
            ValidAudience = audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
        };
    });



// registra todos os profiles automaticamente
builder.Services.AddAutoMapper(typeof(Program));

// Adiciona controllers
builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configura CORS para permitir chamadas do frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy.WithOrigins("http://localhost:3000") // origem do Next.js
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

// Registra o serviço no DI
builder.Services.AddScoped<SolicitacaoModelsService>();
builder.Services.AddScoped<ISolictacaoModelsReposirory, SolicitacaoModelsRepository>();



// Adiciona Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Challenge API",
        Version = "v1"
    });
});

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
// Middleware de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Challenge API v1");
        c.RoutePrefix = "swagger"; // acessível em /swagger
    });
}

// HTTPS redirection
app.UseHttpsRedirection();

// Ativa CORS
app.UseCors("AllowFrontend");

// Autorização (se necessário)
app.UseAuthorization();

// Mapeia controllers
app.MapControllers();

app.Run();
