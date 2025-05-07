using FluentAssertions;
using Fiap_AtividadeCap07.Controllers;
using Fiap_AtividadeCap07.DTOs;
using Fiap_AtividadeCap07.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Fiap_AtividadeCap07.Models;

namespace Fiap_AtividadeCap07.Test.StepDefinitions
{
    [Binding]
    public class SemaforoSteps
    {
        private readonly Mock<ISemaforoService> _serviceMock = new();
        private SemaforoController _controller;
        private ActionResult<IEnumerable<DTOs.SemaforoDTO>> _result;

        [Given(@"que existem semáforos cadastrados")]
        public void GivenQueExistemSemaforosCadastrados()
        {
            var semaforos = new List<Models.SemaforoDTO>
            {
                new() { CorAtual = "Verde", Localizacao = "A" },
                new() { CorAtual = "Vermelho", Localizacao = "B" }
            };

            // Corrigindo a configuração do mock com ReturnsAsync
            _serviceMock.Setup(s => s.GetAllSemaforosAsync(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(Task.FromResult<IEnumerable<Models.SemaforoDTO>>(semaforos));

            _controller = new SemaforoController(_serviceMock.Object);
        }

        [When(@"o cliente solicita a lista de semáforos")]
        public async Task WhenOClienteSolicitaAListaDeSemaforos()
        {
            _result = await _controller.GetSemaforos(1, 10);
        }

        [Then(@"a API deve retornar status 200")]
        public void ThenAApiDeveRetornarStatus200()
        {
            var okResult = _result.Result as OkObjectResult;
            okResult.Should().NotBeNull();
        }

        [Then(@"a lista deve conter (.*) semáforos")]
        public void ThenAListaDeveConterXSemaforos(int count)
        {
            var okResult = _result.Result as OkObjectResult;
            var lista = okResult?.Value as IEnumerable<DTOs.SemaforoDTO>;
            lista.Should().HaveCount(count);
        }
    }
}
