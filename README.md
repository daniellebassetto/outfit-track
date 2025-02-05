# OutfitTrack

**OutfitTrack** é uma API desenvolvida em **.NET 9** com C# para gerenciar "malinhas" de roupas e calçados, um modelo de negócio muito comum em cidades pequenas. Inspirado no controle manual realizado pela loja de roupas dos meus pais, localizada em Garça/SP, o projeto proporciona uma solução digital eficiente para o dia a dia.

---

## 🌟 Funcionalidades

- **CRUD completo** para **Product**, **Customer**, **Order** e manipulação de **OrderItem** via entidade pai (**Order**).
- **Busca por identificador específico** com os endpoints `GetByIdentifier`.
- **Documentação interativa** com **Swagger**, facilitando a exploração dos endpoints.
- **Validações** de integridade dos dados e **Regras de negócio**
- **Controle de Status do condicional e de cada item do mesmo**

---

## 🛠 Tecnologias Utilizadas

- **.NET 9**
- **C#**
- **Entity Framework Core** com Fluent API
- **LINQ e Funções Lambda**
- **MySQL** para banco de dados
- **Swagger** para documentação de API
- **Dependabot** para automação de dependências

---

## 📂 Arquitetura

Adotando os princípios da **Clean Architecture**:
- **Domain**: Contém as entidades e regras de negócio.
- **Application**: Abriga os serviços e interfaces.
- **Cross-Cutting**: Centraliza as injeções de dependência.
- **Infrastructure**: Implementa o acesso ao banco de dados MySQL.
- **API**: Expõe os endpoints da aplicação.

Além disso, o projeto utiliza conceitos como:
- **DRY** (*Don’t Repeat Yourself*): Reduz redundâncias, centralizando lógicas e promovendo reutilização de código.
- **KISS** (*Keep It Simple, Stupid*): Soluções diretas e de fácil compreensão.
- **Clean Code**: Código limpo e organizado, facilitando a manutenção e legibilidade.

---

## ✨ Por que automatizar?

Automatizar o processo de gerenciamento das "malinhas" trouxe diversos benefícios:
- **Precisão**: Evita erros manuais comuns no registro em cadernos.
- **Eficiência**: A busca e atualização de informações são instantâneas.
- **Escalabilidade**: Permite gerenciar um volume maior de pedidos e clientes sem aumento significativo de esforço.
- **Histórico organizado**: Todas as informações ficam registradas no banco de dados de forma centralizada.

A transformação digital desse modelo é essencial para competir no mercado e atender clientes de forma mais profissional.

---

## 🤖 Dependabot

O **Dependabot** foi integrado ao projeto para manter as dependências sempre atualizadas automaticamente. Isso garante:
- **Segurança**: Evita vulnerabilidades conhecidas em bibliotecas desatualizadas.
- **Estabilidade**: Reduz problemas decorrentes de versões antigas e incompatibilidades.
- **Produtividade**: Economiza tempo da equipe ao gerenciar as atualizações de forma automática.

---

## 📜 Endpoints

### Customer
- **GET** `/api/Customer` - Lista todos os clientes.  
- **POST** `/api/Customer` - Cadastra um novo cliente.  
- **GET** `/api/Customer/{id}` - Retorna um cliente específico.  
- **PUT** `/api/Customer/{id}` - Atualiza as informações de um cliente.  
- **DELETE** `/api/Customer/{id}` - Remove um cliente.  
- **POST** `/api/Customer/GetByIdentifier` - Busca um cliente por identificador específico (CPF).  

### Order
- **PUT** `/api/Order/Close/{id}` - Fecha um pedido.  
- **GET** `/api/Order` - Lista todos os pedidos.  
- **POST** `/api/Order` - Cria um novo pedido.  
- **GET** `/api/Order/{id}` - Retorna um pedido específico.  
- **PUT** `/api/Order/{id}` - Atualiza as informações de um pedido.  
- **DELETE** `/api/Order/{id}` - Remove um pedido.  
- **POST** `/api/Order/GetByIdentifier` - Busca um pedido por identificador específico (Number).  

### Product
- **GET** `/api/Product` - Lista todos os produtos.  
- **POST** `/api/Product` - Cadastra um novo produto.  
- **GET** `/api/Product/{id}` - Retorna um produto específico.  
- **PUT** `/api/Product/{id}` - Atualiza as informações de um produto.  
- **DELETE** `/api/Product/{id}` - Remove um produto.  
- **POST** `/api/Product/GetByIdentifier` - Busca um produto por identificador específico (Code).  

---

## ⚙️ Configuração

### Pré-requisitos
- **.NET 9 SDK**
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
