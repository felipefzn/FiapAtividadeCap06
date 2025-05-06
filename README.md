# Projeto .NET com CI/CD e Docker

## 💡 Descrição
Este projeto é um exemplo de aplicação .NET 8 com pipeline de CI/CD usando GitHub Actions e containerização com Docker. Ele inclui processos automatizados para build, testes e deploy em ambientes de *staging* e *produção*.

---

## ⚙️ Requisitos

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/)
- Git
- (Opcional) Acesso a um servidor para staging/produção via SSH

---

## 🚀 Executando o projeto

### ✔️ Localmente

```bash
dotnet restore
dotnet build
dotnet run
```

A aplicação rodará localmente em: `https://localhost:5001` ou `http://localhost:5000`.

---

### 🐳 Usando Docker

**1. Construir a imagem Docker:**

```bash
docker build -t nome-do-projeto .
```

**2. Executar o container:**

```bash
docker run -d -p 5000:80 nome-do-projeto
```

---

## ⚡ CI/CD com GitHub Actions

A pipeline está configurada para:

- Executar build e testes ao dar push na branche `master`
- Fazer deploy automático para:
  - **Staging**, ao dar push na branch `master`
  - **Produção**, ao dar push na branch `master`

### Caminho do pipeline:

```
.github/workflows/ci-cd.yml
```

---

## 📂 Estrutura

```
/.github/workflows/ci-cd.yml     # CI/CD com GitHub Actions
/scripts/deploy-staging.sh       # Script para deploy em staging
/scripts/deploy-production.sh    # Script para deploy em produção
/Dockerfile                      # Dockerfile do projeto
/README.txt                      # Este arquivo
/src/                            # Código-fonte do projeto
```