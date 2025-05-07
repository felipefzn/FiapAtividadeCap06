using FluentAssertions;
using Fiap_AtividadeCap07.Controllers;
using Fiap_AtividadeCap07.DTOs;
using Fiap_AtividadeCap07.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.Language.Flow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Fiap_AtividadeCap07.Test.StepDefinitions
{
    [Binding]
    public class AcidenteSteps
    {
        private readonly Mock<IAcidenteService> _serviceMock = new();
        private AcidenteController _controller;
        private ActionResult<IEnumerable<AcidenteDTO>> _result;

        private List<AcidenteDTO> _acidentes;

        [Given(@"que existem acidentes cadastrados")]
        public void GivenQueExistemAcidentesCadastrados()
        {
            // Criando uma lista explícita de acidentes com o tipo Models.AcidenteDTO
            var acidentes = new List<Models.AcidenteDTO>
            {
                new Models.AcidenteDTO { Descricao = "Acidente 1", Localizacao = "A", DataHora = DateTime.Now },
                new Models.AcidenteDTO { Descricao = "Acidente 2", Localizacao = "B", DataHora = DateTime.Now }
            };

            // Configurando o mock para retornar uma Task com a lista de Models.AcidenteDTO
            _serviceMock
                .Setup(s => s.GetAllAcidentesAsync(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(Task.FromResult<IEnumerable<Models.AcidenteDTO>>(acidentes));  // Usando o tipo correto

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
            _result.Result.Should().BeOfType<OkObjectResult>();
        }

        [Then(@"a lista deve conter (.*) acidentes")]
        public void ThenAListaDeveConterXAcidentes(int count)
        {
            var okResult = _result.Result as OkObjectResult;
            var lista = okResult?.Value as IEnumerable<AcidenteDTO>;
            lista.Should().HaveCount(count);
        }
    }
}
