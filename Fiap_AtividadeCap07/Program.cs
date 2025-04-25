using Fiap_AtividadeCap07.Authorization;
using Fiap_AtividadeCap07.Data;
using Fiap_AtividadeCap07.Repositories;
using Fiap_AtividadeCap07.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Leitura do ambiente: Development, Staging, Production
var environment = builder.Environment.EnvironmentName;

// Configuração do banco de dados com base no ambiente
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Injeção de dependências
builder.Services.AddScoped<IAcidenteService, AcidenteService>();
builder.Services.AddScoped<IAcidenteRepository, AcidenteRepository>();
builder.Services.AddScoped<ISemaforoService, SemaforoService>();
builder.Services.AddScoped<ISemaforoRepository, SemaforoRepository>();

// JWT (caso queira adicionar autenticação)
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var key = builder.Configuration["AppSettings:ChaveAPI"];
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Ativa o Swagger em Development e Staging
if (app.Environment.IsDevelopment() || app.Environment.EnvironmentName == "Staging")
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<TokenMiddleware>();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
