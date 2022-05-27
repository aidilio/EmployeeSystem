## EmployeeSystem

This repository contains a simple object model for calculating salaries within an organization. The model consists of three entities:
 - `Employee`
 - `Manager`
 - `SalesManager`

`Employee` serves as the base class and contains most of the general functionality. `Manager` inherits from `Employee`, and `SalesManager` inherits from `Manager`. This was done to reduce code repetition. The primary functionality of the current version of the system is the `GetSalary()` method, which is defined in `Employee`. When changes are needed in how salary is calculated, child classes can override the `CalculateSalary()` method. 

Some limitations of this architecture:
 - This architecture is well-suited for systems that are not heavily dependant on relational database access. If our system were data-centric, then other approaches could be better.
 - When calculating a salary for some date, we can have a dictionary that will store the calculated value. The next time we need this salary amount (for example when calculating a salary of a manager), we can just retrieve it from the dictionary instead of recalculating.
 - To calculate the salary of all employees, a simple `foreach` iteration was used. To avoid recalculation of salaries, we could also introduce a dictionary here.
 - For the dictionary approach to be possible, we need to add an additional property to our base `Employee` class, namely, the unique `Id`.