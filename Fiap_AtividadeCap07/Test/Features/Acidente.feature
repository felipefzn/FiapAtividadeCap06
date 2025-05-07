Feature: API de Acidentes
  Para garantir que os usuários possam consultar informações sobre acidentes
  Como cliente da API
  Eu quero obter corretamente os dados dos acidentes cadastrados

  Scenario: Obter lista de acidentes com sucesso
    Given que existem 2 acidentes cadastrados
    When o cliente solicita a lista de acidentes
    Then a API deve retornar status 200
    And a lista deve conter 2 acidentes

  Scenario: Nenhum acidente encontrado
    Given que não existem acidentes cadastrados
    When o cliente solicita a lista de acidentes
    Then a API deve retornar status 200
    And a lista deve estar vazia

  Scenario: Erro interno ao buscar acidentes
    Given que o serviço de acidentes está indisponível
    When o cliente solicita a lista de acidentes
    Then a API deve retornar status 500
    And a resposta deve conter a mensagem "Erro interno no servidor"
