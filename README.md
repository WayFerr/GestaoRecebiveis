
# Gestão de Recebíveis - Teste Técnico Size

Este repositório contém a implementação do desafio técnico proposto pela Size para a vaga de desenvolvedor backend .NET.

## 📦 Informações para rodar o projeto

Para rodar o projeto localmente, você precisa configurar a `ConnectionString` no arquivo `appsettings.Development.json`.

### Exemplo de configuração:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=localhost\\SQLEXPRESS;Initial Catalog=GestaoRecebiveis;User Id=sa;Password=sa1234;TrustServerCertificate=True;MultipleActiveResultSets=True;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
```

> ⚠️ Este arquivo foi omitido do repositório por conter informações sensíveis. Crie-o manualmente com base no exemplo acima, ajustando os dados conforme seu ambiente.

---

## 🧪 Funcionalidades implementadas

- Cadastro de empresas com CNPJ único
- Cadastro de ramos de atividade
- Adição e remoção de notas fiscais no carrinho de antecipação
- Cálculo de antecipação com aplicação de deságio (Checkout)
- Restrições de unicidade, limites e regras de negócio
- Aplicação seguindo boas práticas de DDD, SOLID e uso de injeção de dependência

---

## 🗄 Backup do banco

Um arquivo `.bak` com o banco de dados será entregue juntamente com este código.
