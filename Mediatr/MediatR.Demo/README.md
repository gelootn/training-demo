# MediatR Demo Solution
This is a demo solution to show how to use MediatR in a .NET Core application.
## The Basics
### What is MediatR?
MediatR is a simple mediator implementation in .NET. It allows communication between different parts of the application through a mediator. It also helps to reduce coupling between different parts of the application.
### What is a mediator?
A mediator is an object that encapsulates how a set of objects interact. It is a behavioral design pattern that promotes loose coupling by keeping objects from referring to each other explicitly, and it allows their interaction to vary independently.
### What is a mediator pipeline?
A mediator pipeline is a chain of handlers that are executed in a specific order. The pipeline is executed when a request is sent to the mediator. The pipeline can be customized by adding behaviors to the pipeline.
### What is a mediator behavior?
A mediator behavior is a class that implements the `IPipelineBehavior` interface. It can be used to customize the mediator pipeline.
### What is a mediator notification?
A mediator notification is a class that implements the `INotification` interface. It is used to notify other parts of the application that something has happened.
### What is a mediator notification handler?
A mediator notification handler is a class that implements the `INotificationHandler` interface. It is used to handle a mediator notification.
### What is a mediator request?
A mediator request is a class that implements the `IRequest` interface. It is used to request something from other parts of the application.
### What is a mediator request handler?
A mediator request handler is a class that implements the `IRequestHandler` interface. It is used to handle a mediator request.
## The Demo
### The Solution
The solution consists of three projects: 
- `MediatR.Demo.EndPoint`: A .NET Core Web API project that exposes a REST API.
- `MediatR.Demo.BLL`: A .NET Core class library project with all IRequest and IRequestHandlers .
- `MediatR.Demo.DAL`: A .NET Core class library project that contains the database logic.
- `MediatR.Demo.Framework`: A .NET Core class library project that contains the infrastructure logic.

### Used Packages
The following packages are used in this solution:
- `MediatR`: The main package that contains the MediatR logic.
- `FluentValidation`: The package that is used to add validation to the requests.
- `AutoMapper`: The package that is used to map the entities to the DTOs.
- `Microsoft.EntityFrameworkCore`: The package that is used to add Entity Framework Core to the solution.
- `Microsoft.EntityFrameworkCore.SqlServer`: The package that is used to add SQL Server support to Entity Framework Core.

### The Domain
The domain consists of four entities: `Company`, `Employee`, `Visit` and `Visitor`. A `Company` has many `Employees`. An `Employee` has many `Visits`. And a `Visitor` has many `Visits`.
### The API
The API exposes the following endpoints:
- `GET /api/companies`: Gets all companies.
- `GET /api/companies/{id}`: Gets a company by id.
- `POST /api/companies`: Creates a new company.
- `PUT /api/companies/{id}`: Updates a company by id.
- `DELETE /api/companies/{id}`: Deletes a company by id.
- `GET /api/companies/{id}/employees`: Gets all employees of a company.
- `GET /api/companies/{id}/employees/{employeeId}`: Gets an employee of a company by id.
- `POST /api/companies/{id}/employees`: Creates a new employee of a company.
- `PUT /api/companies/{id}/employees/{employeeId}`: Updates an employee of a company by id.
- `DELETE /api/companies/{id}/employees/{employeeId}`: Deletes an employee of a company by id.
- `GET /api/visits`: Gets all visits.
- `GET /api/visits/open`: Gets all open visits.

The API uses the following DTOs:
- `CompanyModel`: A DTO for a company.
- `EmployeeModel`: A DTO for an employee.
- `VisitModel`: A DTO for a visit.
- `StartVisitModel`: A DTO to start a visit.
- `StopVisitModel`: A DTO to end a visit.

### The BLL
The BLL contains the following requests:


