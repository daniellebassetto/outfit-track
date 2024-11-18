# OutfitTrack

**OutfitTrack** é uma API desenvolvida em **.NET 8** com C# para gerenciar "malinhas" de roupas e calçados, um modelo de negócio comum em cidades pequenas. Foi inspirado no controle manual realizado pela loja de roupas dos meus pais, localizada em Garça/SP, proporcionando uma solução digital eficiente.

---

## Funcionalidades

- **CRUD completo** para **Product**, **Customer**, **Order** e manipulação de **OrderItem** via entidade pai (**Order**).
- **Documentação interativa** com **Swagger**, facilitando a exploração dos endpoints.
- Configurações centralizadas para banco de dados no arquivo **appsettings.json**.

---

## Tecnologias Utilizadas

- **.NET 8**
- **C#**
- **Entity Framework Core** com Fluent API
- LINQ e Funções Lambda
- **MySQL** para banco de dados
- **Swagger** para documentação de API

---

## Arquitetura

Adotando os princípios da **Clean Architecture**:
- **Domain**: Contém as entidades e regras de negócio.
- **Application**: Abriga os serviços e interfaces.
- **Cross-Cutting**: Centraliza as injeções de dependência.
- **Infrastructure**: Implementa o acesso ao banco de dados MySQL.
- **API**: Expõe os endpoints da aplicação.
Obs: foi utilizado polimorfismo e herança para centralizar funções comuns e garantir um código mais low code ao criar, por exemplo, uma nova entidade.

Princípios adicionais:
- **DRY** (Don’t Repeat Yourself)
- **KISS** (Keep It Simple, Stupid)
- **Clean Code**

---

## Endpoints

### Customer
- **GET** `/api/Customer`  
  Lista todos os clientes.  
- **POST** `/api/Customer`  
  Cadastra um novo cliente.  
- **GET** `/api/Customer/{id}`  
  Retorna um cliente específico.  
- **PUT** `/api/Customer/{id}`  
  Atualiza as informações de um cliente.  
- **DELETE** `/api/Customer/{id}`  
  Remove um cliente.  
- **POST** `/api/Customer/GetByIdentifier`  
  Busca um cliente por identificador específico (CPF).  

### Order
- **PUT** `/api/Order/Close/{id}`  
  Fecha um pedido.  
- **GET** `/api/Order`  
  Lista todos os pedidos.  
- **POST** `/api/Order`  
  Cria um novo pedido.  
- **GET** `/api/Order/{id}`  
  Retorna um pedido específico.  
- **PUT** `/api/Order/{id}`  
  Atualiza as informações de um pedido.  
- **DELETE** `/api/Order/{id}`  
  Remove um pedido.  
- **POST** `/api/Order/GetByIdentifier`  
  Busca um pedido por identificador específico (Number).  
- **Observação**: **OrderItem** é manipulado exclusivamente por meio da entidade pai **Order**.

### Product
- **GET** `/api/Product`  
  Lista todos os produtos.  
- **POST** `/api/Product`  
  Cadastra um novo produto.  
- **GET** `/api/Product/{id}`  
  Retorna um produto específico.  
- **PUT** `/api/Product/{id}`  
  Atualiza as informações de um produto.  
- **DELETE** `/api/Product/{id}`  
  Remove um produto.  
- **POST** `/api/Product/GetByIdentifier`  
  Busca um produto por identificador específico (Code).  

---

## Configuração

### Pré-requisitos
- **.NET 8 SDK**
- **MySQL** instalado e configurado
- Ferramenta de gerenciamento de dependências, como NuGet

### Passos para Execução
1. Clone o repositório:
   ```bash
   git clone https://github.com/daniellebassetto/outfit-track.git
   ```
2. Configure a string de conexão no arquivo **appsettings.json**:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=seu-servidor;Database=sua-base;User Id=seu-usuario;Password=sua-senha;"
     }
   }
   ```
3. Execute as migrações para preparar o banco:
   ```bash
   dotnet ef database update
   ```
4. Inicie a aplicação:
   ```bash
   dotnet run
   ```
5. Acesse a API nos seguintes endereços:
   - HTTPS: [https://localhost:3001](https://localhost:3001)
   - HTTP: [http://localhost:3002](http://localhost:3002)

---

