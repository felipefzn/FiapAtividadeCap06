using Moq;
using Fiap_AtividadeCap07.Controllers;
using Fiap_AtividadeCap07.Services;
using Fiap_AtividadeCap07.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Fiap_AtividadeCap07.Test
{
    public class AcidenteControllerTest
    {
        private readonly Mock<IAcidenteService> _acidenteServiceMock;
        private readonly AcidenteController _controller;

        public AcidenteControllerTest()
        {
            _acidenteServiceMock = new Mock<IAcidenteService>();
            _controller = new AcidenteController(_acidenteServiceMock.Object);
        }

        [Fact]
        public async Task GetAllAcidentes_ReturnsOkResult_WithAcidenteDTOs()
        {
            var acidenteDTOs = new List<AcidenteDTO>
            {
                new() { Descricao = "Acidente 1", Localizacao = "Local 1", DataHora = DateTime.Now },
                new() { Descricao = "Acidente 2", Localizacao = "Local 2", DataHora = DateTime.Now }
            };

            _acidenteServiceMock
                .Setup(service => service.GetAllAcidentesAsync(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(acidenteDTOs);

            var result = await _controller.GetAcidentes(1, 10);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<AcidenteDTO>>(okResult.Value);
            Assert.Equal(2, returnValue.Count());
        }
    }
}
