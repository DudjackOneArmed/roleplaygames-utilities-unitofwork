# Database

Several utils packages to work with database:
 - Unit of work

## Unit of work

Realization of Unit of work pattern.

### Unit of work - Contracts

Contracts to work with database with Unit of work.
Use Entity base for all your project's entities.

### Unit of work - EF

Realization of Unit of work pattern with entity framework core.
Readonly repositories return item as no tracking.

### Unit of work - EF DI

Extensions to register Unit of work services. Support next IoC:
 - Autofac
 - Microsoft.DependencyInjection (need to register repositories for each entity type)

 #### Microsoft injection

 To register services with microsoft injection call next methods on your IServiceCollection instance:
 ```
 using Microsoft.DependencyInjection;

 // ...

	serviceCollaction.AddUnitOfWork();
	serviceCollaction.AddRepository<TEntity1Type>();
	serviceCollaction.AddRepository<TEntity2Type>();
	// And next for all repositories types call AddRepository method

 // ...
 ```