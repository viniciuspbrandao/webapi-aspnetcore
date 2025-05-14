# WebApi .NET 8 - Projeto de Estudo

Este é um projeto de estudo desenvolvido com o objetivo de praticar os conceitos fundamentais de construção de uma API RESTful utilizando o **.NET 8**, **JWT para autenticação**, **AutoMapper para mapeamento de objetos**, integração com banco de dados **SQL** e documentação com **Swagger**.

---

## 🚀 Tecnologias utilizadas

- [.NET 8](https://dotnet.microsoft.com/en-us/)
- [ASP.NET Core Web API](https://learn.microsoft.com/aspnet/core/web-api/)
- [AutoMapper](https://automapper.org/)
- [Entity Framework Core](https://learn.microsoft.com/ef/core/)
- [JWT Bearer Authentication](https://jwt.io/)
- [Swagger / Swashbuckle](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)
- Banco de dados: **MySQL**
- Controle de versão: **Git** e **GitHub**

---


## 🔐 Autenticação com JWT

A aplicação utiliza **JWT (JSON Web Tokens)** para autenticação. O token é gerado e validado a cada requisição protegida, garantindo segurança no acesso a recursos.

---

## 🔁 Mapeamento com AutoMapper

Foi utilizado o AutoMapper para converter entidades (`Model`) em `DTOs` e `ViewModels`, facilitando a separação entre as camadas da aplicação.

---

## 📄 Swagger

A documentação da API está disponível via Swagger, permitindo testar os endpoints diretamente pelo navegador.

Acesse: `https://localhost:{porta}/swagger`

---

## 🛠 Funcionalidades Implementadas

- [x] Autenticação com JWT
- [x] Cadastro e listagem de funcionários (Employee)
- [x] Integração com banco de dados SQL via EF Core
- [x] Paginação nas listagens
- [x] Mapeamento de entidades com AutoMapper
- [x] Configuração e exibição da documentação via Swagger

---
