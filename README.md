# Sistema de Oficina de Manutenção de Veículos

## Descrição do Projeto
O Sistema de Oficina de Manutenção de Veículos é uma aplicação destinada a automatizar e digitalizar processos em uma oficina, gerenciando orçamentos, peças e movimentação de estoque. O sistema permite o cadastro de orçamentos, além da entrega de peças e integração com uma API externa para validação de endereços.

## Tecnologias Utilizadas
![.NET 8](https://img.shields.io/badge/.NET%208-512BD4?style=flat-square&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=flat-square&logo=csharp&logoColor=white)
![Entity Framework Core](https://img.shields.io/badge/Entity%20Framework%20Core-5B2D88?style=flat-square&logo=dotnet&logoColor=white)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-336791?style=flat-square&logo=postgresql&logoColor=white)
![Docker](https://img.shields.io/badge/Docker-2496ED?style=flat-square&logo=docker&logoColor=white)
![Swagger](https://img.shields.io/badge/Swagger-85EA2D?style=flat-square&logo=swagger&logoColor=black)

## Executando a Aplicação Localmente
Para executar a aplicação localmente, siga os passos abaixo:

1. **Clone o repositório:**
    ```bash
    git clone https://github.com/MateusDDev/processo-seletivo-ultracar
    cd processo-seletivo-ultracar
    ```

2. **Restaure as dependências do projeto:**
    ```bash
    dotnet restore
    ```

3. **Inicie os serviços utilizando Docker Compose:**

    ```bash
    docker-compose up -d
    ```

4. **Aplique as migrações do banco de dados:**

   ```bash
   cd src
   dotnet ef database update
   ```

5. **Acesse a documentação da API:**

   Após a aplicação ter iniciado a documentação estará disponível em [`http://localhost:5230/swagger`](http://localhost:5230/swagger).

## Observações
- Para facilitar os testes das rotas, um arquivo JSON do Insomnia está disponível no repositório. Você pode importar esse arquivo diretamente no Insomnia para testar os diferentes endpoints da API.

- O projeto utiliza Docker Compose para facilitar a execução do ambiente de desenvolvimento. É necessário que o Docker e o Docker Compose estejam instalados em sua máquina.

