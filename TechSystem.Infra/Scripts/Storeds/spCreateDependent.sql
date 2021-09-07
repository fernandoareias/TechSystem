-- Stored responsável por criar o Dependente no banco.

CREATE PROCEDURE spCreateDependent
    @Id UNIQUEIDENTIFIER,
    @EmployeeId UNIQUEIDENTIFIER,
    @FirstName VARCHAR(30),
    @LastName VARCHAR(30)
AS
INSERT INTO [Dependents]
    (
    [Id],
    [EmployeeId],
    [FirstName],
    [LastName]
    )
VALUES(
        @Id,
        @EmployeeId,
        @FirstName,
        @LastName
)