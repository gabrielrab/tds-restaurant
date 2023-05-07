# Controle de Mesas de Restaurante

<img alt="Logo" align="right" src="https://www.utfpr.edu.br/icones/cabecalho/logo-utfpr/@@images/efcf9caf-6d29-4c24-8266-0b7366ea3a40.png" width="128" />

Esse é um projeto de cunho académico realizado na disciplina de Tecnologia em Desenvolvimento de Sistemas. O objetivo geral do projeto é construir uma aplicação que faca o gerenciamento e gestão de um restaurante com funcionalidade de cadastro de pedidos, produtos, categorização, disponibilidade de mesas, gestão de garcons entre outros. O projeto foi construído em C# utilizando Entity Framework com um banco de dados em memória (SQLite), Razor Pages com engine de renderização para o frontend e a biblioteca de estilização CSS chamada Tailwind.

### Estrutura de pastas do projeto

```javascript
.
├── Controllers
├── Data // pasta com as interfaces com o banco de dados
│   └── Repository
│       ├── DbContext.cs
│       └── Models // pasta com as models do projeto
├── Makefile
├── Migrations // pasta onde é localizado as migrations executadas no projeto
├── Pages // pasta com todas as páginas a renderizadas no projeto
│   ├── CloseService
│   ├── Components
│   │   ├── ConfigurationMenu
│   │   ├── Footer
│   │   └── Header
│   ├── Configurations
│   │   ├── Categories
│   │   ├── Index.cshtml
│   │   ├── Index.cshtml.cs
│   │   ├── Products
│   │   ├── Tables
│   │   └── Waiters
│   ├── Index.cshtml
│   ├── Index.cshtml.cs
│   ├── OrderDetails
│   ├── Orders
│   ├── Shared
│   ├── _Imports.razor
│   └── _ViewStart.cshtml
├── Program.cs // arquivo de configuração
├── Properties
│   └── launchSettings.json
├── Restaurant.View.csproj
├── app.db // arquivo de banco de dados SQLite
├── appsettings.json
├── readme.md
├── tailwind.config.js // arquivo da biblioteca de componentes Tailwind
└── wwwroot

```

### Como rodar o projeto

- O primeiro passo é verificar a existência dos arquivos `app.db`, `app.db-shm`, `app.db-wal`. Caso os mesmos existam é necessário excluir.
- O segundo passo é semelhante ao primeiro, porém é realizado na pasta `Migrations`. Nela deve-se realizar a exclusão de todos arquivos com a exceção do arquivo `.gitkeep`
- O próximo passo é executar as _migrations_ e para isso primeiro você deve executar o comando `dotnet ef migrations add Inital` e em seguida o comando `dotnet ef database update`.
- Por último utilize o comando `dotnet watch run` ou apenas `dotnet run` para iniciar a aplicação.
