using FluentAssertions;
using Fiap_AtividadeCap07.Controllers;
using Fiap_AtividadeCap07.Models;
using Fiap_AtividadeCap07.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using TechTalk.SpecFlow;

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
            var semaforos = new List<SemaforoDTO>
            {
                new() { CorAtual = "Verde", Localizacao = "A" },
                new() { CorAtual = "Vermelho", Localizacao = "B" }
            };

            _serviceMock.Setup(s => s.GetAllSemaforosAsync(1, 10)).ReturnsAsync(semaforos);
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
            _result.Should().BeOfType<OkObjectResult>();
        }

        //[Then(@"a lista deve conter (.*) semáforos")]
        //public void ThenAListaDeveConterXSemaforos(int count)
        //{
        //    var okResult = _result as OkObjectResult;
        //    var lista = okResult?.Value as IEnumerable<SemaforoDTO>;
        //    lista.Should().HaveCount(count);
        //}
    }
}
