using Fiap_AtividadeCap07.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiap_AtividadeCap07.Data
{
    public static class DatabaseInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = serviceProvider.GetRequiredService<CityTrafficDbContext>();
            context.Database.Migrate();

            if (!context.Acidentes.Any())
            {
                context.Acidentes.AddRange(
                    new Acidente
                    {
                        Descricao = "Acidente na Avenida X",
                        Localizacao = "Avenida X, Centro",
                        Gravidade = "Leve",
                        DataHora = DateTime.Now
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
