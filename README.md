
# .NET API Course

##💡💡 UNDER DEV 💡💡

This API is currently under development and serves as a course example for building a robust API using .NET. The current version includes user registration and login functionalities, with a focus on implementing best practices in architecture and design.

## Course Overview

In this course, you will learn how to build a scalable API with .NET by following a layered architecture. We'll explore the following key concepts:

### 1. Controllers

Controllers are the entry point of the API. They handle HTTP requests, communicate with service layers, and return appropriate responses. In this course, we'll cover:

- Creating and organizing controllers
- Handling HTTP verbs (GET, POST, PUT, DELETE)
- Managing routing and model binding
- Implementing validation and error handling

### 2. Repository Layer

The repository layer is responsible for interacting with the database. It abstracts the data access logic and provides a clean API for the service layer. Topics include:

- Designing repositories for CRUD operations
- Implementing repository interfaces
- Utilizing Entity Framework Core for data persistence
- Testing repository methods

### 3. Service Layer

The service layer contains the business logic of the application. It acts as a bridge between the controllers and the repository layer. We'll learn about:

- Structuring service classes
- Managing business rules and workflows
- Handling exceptions and transactions
- Injecting dependencies into services

### 4. Dependency Injection (DI)

Dependency Injection is a key design pattern used to achieve loosely coupled code. In this course, we'll cover:

- Configuring DI in .NET
- Registering services and repositories with the DI container
- Injecting dependencies into controllers and services
- Managing the lifecycle of dependencies

### 5. Models

Models represent the data structure of the application. They are used for both data persistence and data transfer. Topics include:

- Creating and organizing models
- Using data annotations for validation
- Mapping models to database entities
- Implementing AutoMapper for object-to-object mapping

## Current Features

### User Registration and Login

The current version of the API includes the following features:

- **User Registration:** Allows new users to create an account by providing necessary details such as username, email, and password.
- **User Login:** Enables users to log in to the system by verifying their credentials and generating a JWT token for authentication.

## Getting Started

### Prerequisites

Before you begin, ensure you have the following installed:

- [.NET SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or any other compatible database

### Cloning the Repository

To clone this repository to your local machine, run:

```bash
git clone https://github.com/your-username/dotnet-api-course.git
```
```
cd dotnet-api-course
```
```
dotnet restore
```
```
dotnet build --configuration Release
```

## Build Outputs

The build outputs can be found in the `bin/Release` directory.

## Resources

For more information on .NET development, refer to the official documentation:

- [.NET Documentation](https://docs.microsoft.com/dotnet/)
- [Entity Framework Core Documentation](https://docs.microsoft.com/ef/)

## Contributing

Contributions are welcome! Feel free to fork this repository and create a pull request to add new features, improve existing code, or fix bugs.
