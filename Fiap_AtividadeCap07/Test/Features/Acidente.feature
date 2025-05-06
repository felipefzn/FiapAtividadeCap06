Feature: API de Acidentes

  Scenario: Obter lista de acidentes com sucesso
    Given que existem acidentes cadastrados
    When o cliente solicita a lista de acidentes
    Then a API deve retornar status 200
    And a lista deve conter 2 acidentes
