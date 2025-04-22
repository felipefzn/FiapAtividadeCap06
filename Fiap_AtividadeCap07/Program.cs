using Fiap_AtividadeCap07.Authorization;
using Fiap_AtividadeCap07.Data;
using Fiap_AtividadeCap07.Repositories;
using Fiap_AtividadeCap07.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAcidenteService, AcidenteService>();
builder.Services.AddScoped<IAcidenteRepository, AcidenteRepository>();
builder.Services.AddScoped<ISemaforoService, SemaforoService>();
builder.Services.AddScoped<ISemaforoRepository, SemaforoRepository>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
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