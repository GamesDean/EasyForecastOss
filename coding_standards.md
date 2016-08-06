# Coding standards

Publish code to a shared repository following the [GitHub Flow] workflow.

Code metrics (from [Building Maintainable Software] )

  - Units (methods and constructors), Limit the length of code units to 15 lines of code
  - Units, Limit the number of branch points (paths through a piece of code) per unit to 4
  - Units, Limit the number of parameters per unit to at most 4
  - Class, Split Classes to Separate Concerns (_Single Responsibility Principle_) 
  - Class, Hide Specialized Implementations Behind Interfaces (_As a rule of thumb, an interface should be implemented by at least two classes in your codebase_)
  - Package/Solution, Couple architecture components loosely
  - Package/Solution: Keep architecture components balanced (_number of components is close to 9 (i.e., between 6 and 12) and that the components are of approximately equal size_)

Testing:
  - Write tests for all the code (don't write tests when is impossible, not feasible...)
  - Automate development pipeline and tests  
  
Refactoring:
  - We should and have to incrementally improving our code, making one small change at a time and committing various versions.
 
Single Responsibility Principle (SRP): every class, function, and variable should have only one purpose (should have one, and only one, reason to change) + no other class shares that specific responsibility
  - Follow the single responsibility principle to get a design with several short, simple, standalone functions. Each one is easy to read, maintain, and test.

Loose coupling _(dependency inversion principle/inversion of control IOC/dependency injection) (use abstraction and interfaces, per also to facilitate refactoring)_
  - Internal implementation dependencies: use higher-level abstraction <also interfaces> not low-level implementation
  - System dependencies: inject dependencies as function parameters <also interfaces>
  - Library dependencies: inject dependencies as constructor parameters <also interfaces>, IOC/Inversion Of Control containers. As a rule of thumb, do injected abstraction over a concrete implementation for libraries that 1) Have side effects 2) Behave differently in different environments
  - Global variables: inject dependencies as constructor parameters <or as function parameters, using also interfaces>
 
High cohesion _(all the variables and methods should be related, everything should operate at the same level of abstraction, and the pieces should fit neatly together)_

Make your objects as immutable as possible.

Write Query _(functions that return something)_:
  - The function is idempotent: given the same input parameters, the function always returns the exact same result.
  - The function does not have side effects: 
    - does not have any dependencies on other parts of the application other than passed parameters
    - does not change parameters passed to the function <anyway this should not be possible for immutable objects!>
does not modify the state of the outside world in any way (e.g. changing a global variable, writing to the hard disk, reading user input from the console, or receiving data over the network)

Write Commands _(void methods that return nothing other than errors)_:
  - that change the state changing parameters passed to the function (or have others side effects, e.g. changing a global variable, writing to the hard disk, reading user input from the console, or receiving data over the network)

Avoid throwing exceptions, but return a _Compound Object_ (a state + one or more objects), with query and commands. See 
  - [C# functional extensions (NuGet library, By Vladimir Khorikov)] 
  - [Functional C#: Handling failures, input errors (Article By Vladimir Khorikov)] 
  - [Functional C#: Primitive obsession]

Don't write string/num literals in the code, but use class parameters/data structures/constants.

Null:
  - never return Null; return an empty collecition or an empty array if needed, or a compound object (see above)
  - test if a Null argument is passed and the member does not support null arguments; never throw exception 'ArgumentNullException' but return a compound object (see above)

Naming/Layout:
  - Namespace (and directory structure) 
    - ```<Company>.(<Product>|<Technology>)[.<Feature>][.<Subnamespace>]```
    - _e.g. EasyForecast.SymEngine.Json.Input / EasyForecastOss.SymEngine.Json.Input_
  - Assembly/Package
    - ```<Company>.(<Product>|<Technology>)```
  - 1 class per file (but we can have more than one if it makes sense)

Methods definition (write the following _code comment_ before any method):
```
Purpose: Compute the maximum element of an array of decimals 
Name: Maximum 
Inputs: Array Of decimals 
Output/Return: A decimal value 
Side effects: None
Error case: Array must not be null; Array must not be empty 
```

   [Building Maintainable Software]: <https://www.safaribooksonline.com/library/view/building-maintainable-software/9781491967423/>
   [GitHub Flow]: <https://guides.github.com/introduction/flow/index.html>
   [C# functional extensions (NuGet library, By Vladimir Khorikov)]: <http://enterprisecraftsmanship.com/2016/06/24/c-functional-extensions-nuget-library/>
   [Functional C#: Handling failures, input errors (Article By Vladimir Khorikov)]: <http://enterprisecraftsmanship.com/2015/03/20/functional-c-handling-failures-input-errors/>
   [Functional C#: Primitive obsession]: <http://enterprisecraftsmanship.com/2015/03/07/functional-c-primitive-obsession/>
