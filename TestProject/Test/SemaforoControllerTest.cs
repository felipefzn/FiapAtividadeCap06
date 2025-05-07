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
    public class SemaforoControllerTests
    {
        private readonly Mock<ISemaforoService> _semaforoServiceMock;
        private readonly SemaforoController _controller;

        public SemaforoControllerTests()
        {
            _semaforoServiceMock = new Mock<ISemaforoService>();
            _controller = new SemaforoController(_semaforoServiceMock.Object);
        }

        [Fact]
        public async Task GetSemaforos_ReturnsStatusCode200_WithListOfSemaforos()
        {
            var semaforoDTOs = new List<SemaforoDTO>
            {
                new() { CorAtual = "Verde", Localizacao = "Local 1" },
                new() { CorAtual = "Vermelho", Localizacao = "Local 2" }
            };

            _semaforoServiceMock
                .Setup(service => service.GetAllSemaforosAsync(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(semaforoDTOs);

            var result = await _controller.GetSemaforos(1, 10);

            // Acesse o Result da ActionResult para verificar o OkObjectResult
            var okResult = Assert.IsType<OkObjectResult>(result.Result);

            var returnValue = Assert.IsAssignableFrom<IEnumerable<SemaforoDTO>>(okResult.Value);
            Assert.Equal(2, returnValue.Count());
        }

    }
}
