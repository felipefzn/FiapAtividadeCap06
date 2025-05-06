Feature: Consulta de Semáforos

  Scenario: Obter todos os semáforos com sucesso
    Given existem semáforos cadastrados
    When o usuário requisitar a lista de semáforos
    Then o sistema deve retornar uma lista com 2 semáforos

  Scenario: Nenhum semáforo encontrado
    Given não existem semáforos cadastrados
    When o usuário requisitar a lista de semáforos
    Then o sistema deve retornar uma lista vazia

  Scenario: Paginação de semáforos
    Given existem 5 semáforos cadastrados
    When o usuário requisitar a página 1 com tamanho 2
    Then o sistema deve retornar 2 semáforos
