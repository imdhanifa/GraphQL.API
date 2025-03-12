# GraphQL API with Repository Pattern

This repository demonstrates a **layered architecture** with a **repository pattern** for data access, combined with **GraphQL** to expose query and mutation operations. The folder structure clearly separates domain models, data access logic, and GraphQL concerns.

---

## Overview

- **Models**: Domain entities (e.g., `Author`, `Book`).
- **Repositories**: Concrete classes implementing the **repository pattern** (e.g., `AuthorRepository`, `BookRepository`), abstracting data operations.
- **GraphQL**: 
  - **Queries** (`AuthorQuery`, `BookQuery`, etc.) and **Mutations** (`AuthorMutation`, `BookMutation`, etc.) define the read and write operations.
  - **Types** (`AuthorType`, `BookType`, etc.) map domain entities to GraphQL object types.
  - **Schemas** (`AppSchema`, `AuthorSchema`, `BookSchema`) bring together queries, mutations, and types for different domains.
- **Program.cs**: Configures services, registers repositories, sets up GraphQL endpoints, and starts the ASP.NET Core application.

---

## Architecture Highlights

1. **Repository Pattern**  
   - Each repository encapsulates data-access logic for a specific entity, promoting loose coupling and easier testing.

2. **Layered Structure**  
   - **Domain (Models)**: Plain C# objects representing business data.  
   - **Data (Repositories)**: Handles interaction with the data source.  
   - **Presentation (GraphQL)**: Defines GraphQL queries, mutations, and schemas, orchestrating how clients interact with the domain logic.

3. **Multiple Schemas**  
   - Separate schemas for different domains (e.g., `AuthorSchema`, `BookSchema`), each exposed via its own endpoint, plus an overarching `AppSchema` if needed.

4. **GraphQL Endpoints**  
   - Exposes each schema on its own route (e.g., `/graphql/author`, `/graphql/book`, `/graphql/app`).

5. **SDL Export**  
   - The application exports each schema’s SDL (Schema Definition Language) to `.graphql` files (e.g., `Author.graphql`, `Book.graphql`, `App.graphql`), useful for documentation or integration with other tools.

---


## Folder Structure

GraphQL.API
├── GraphQL
│   ├── Mutations
│   │   ├── AuthorMutation.cs
│   │   └── BookMutation.cs
│   ├── Queries
│   │   ├── AuthorQuery.cs
│   │   └── BookQuery.cs
│   ├── Types
│   │   ├── AuthorType.cs
│   │   └── BookType.cs
│   └── Schemas
│       ├── AuthorSchema.cs
│       ├── BookSchema.cs
│       └── AppSchema.cs
├── Models
│   ├── Author.cs
│   └── Book.cs
├── Repositories
│   ├── AuthorRepository.cs
│   └── BookRepository.cs
├── Program.cs
└── README.md

---

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- A code editor or IDE (e.g., Visual Studio, VS Code, Rider)

### Installation & Running

1. **Clone the Repository**  
   ```bash
   git clone https://github.com/{{YourUsername}}/GraphQL.API.git
   cd GraphQL.API
   dotnet restore
   dotnet build
   dotnet run
