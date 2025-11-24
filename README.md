# Sistema de Locação -- Console App (C# + SQL Server + ADO.NET)

Este projeto é um aplicativo console desenvolvido em C#, utilizando
ADO.NET para comunicação com um banco de dados SQL Server.\
O objetivo é fornecer uma base simples e organizada para operações
envolvendo locação de veículos.

## Estrutura do Domínio

O projeto possui as seguintes entidades:

### Cliente

Representa um cliente que pode realizar locações.

### Funcionário

Profissional responsável por gerenciar processos de locação.

### Categoria

Classificação dos veículos, como econômico, SUV, utilitário etc.

### Veículo

Item que pode ser alugado. Cada veículo pertence a uma categoria.

### Documento

Informações documentais necessárias para validação da locação, como CNH.

### Locação

Registro da locação em si, contendo datas, valores, cliente, veículo e
status.

### LocacaoFuncionario

Tabela de relacionamento do tipo M:N entre Locação e Funcionário.\
Uma locação pode envolver vários funcionários, e um funcionário pode
participar de várias locações.

## Conexão com o Banco de Dados

O projeto utiliza uma classe utilitária para acessar a connection string
do SQL Server:

``` csharp
public class ConnectionDB
{
    private static readonly string _connectionString = "";

    public static string GetConnectionString()
    {
        return _connectionString;
    }
}
```

### Como configurar

Nesta classe, você deve definir sua connection string, por exemplo:

Autenticação SQL Server:

    Server=SEU_SERVIDOR;Database=SEU_BANCO;User Id=USUARIO;Password=SENHA;

Autenticação Windows:

    Server=SEU_SERVIDOR;Database=SEU_BANCO;Trusted_Connection=True;

Essa configuração é utilizada por todas as operações de ADO.NET.

## Como executar o projeto

1.  Configure a connection string na classe `ConnectionDB`.

2.  Gere o banco de dados e tabelas conforme o script SQL utilizado no
    projeto.

3.  Compile o projeto:

        dotnet build

4.  Execute:

        dotnet run

## Tecnologias utilizadas

-   C# (.NET)
-   SQL Server
-   ADO.NET
-   Console Application
