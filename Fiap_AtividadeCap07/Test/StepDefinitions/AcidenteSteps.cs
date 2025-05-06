using FluentAssertions;
using Fiap_AtividadeCap07.Controllers;
using Fiap_AtividadeCap07.Models;
using Fiap_AtividadeCap07.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TechTalk.SpecFlow;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Fiap_AtividadeCap07.Test.StepDefinitions
{
    [Binding]
    public class AcidenteSteps
    {
        private readonly Mock<IAcidenteService> _serviceMock = new();
        private AcidenteController _controller;
        private ActionResult<IEnumerable<DTOs.AcidenteDTO>> _result;

        [Given(@"que existem acidentes cadastrados")]
        public void GivenQueExistemAcidentesCadastrados()
        {
            var acidentes = new List<AcidenteDTO>
            {
                new() { Descricao = "Acidente 1", Localizacao = "A", DataHora = DateTime.Now },
                new() { Descricao = "Acidente 2", Localizacao = "B", DataHora = DateTime.Now }
            };

            _serviceMock.Setup(s => s.GetAllAcidentesAsync(1, 10)).ReturnsAsync(acidentes);
            _controller = new AcidenteController(_serviceMock.Object);
        }

        [When(@"o cliente solicita a lista de acidentes")]
        public async Task WhenOClienteSolicitaAListaDeAcidentes()
        {
            _result = await _controller.GetAcidentes(1, 10);
        }

        [Then(@"a API deve retornar status 200")]
        public void ThenAApiDeveRetornarStatus200()
        {
            _result.Should().BeOfType<OkObjectResult>();
        }

        //[Then(@"a lista deve conter (.*) acidentes")]
        //public void ThenAListaDeveConterXAcidentes(int count)
        //{
        //    var okResult = _result as OkObjectResult;
        //    var lista = okResult?.Value as IEnumerable<AcidenteDTO>;
        //    lista.Should().HaveCount(count);
        //}
    }
}
