


-- Stored responsável por criar o Funcionário no banco.

CREATE PROCEDURE spCreateEmployee
    @Id UNIQUEIDENTIFIER,
    @FirstName VARCHAR(30),
    @LastName VARCHAR(30),
    @Wage MONEY,
    @Gender TINYINT,
    @Role TINYINT
AS
INSERT INTO [Employee]
    (
    [Id],
    [FirstName],
    [LastName],
    [Wage],
    [Gender],
    [Role]
    )
VALUES(
        @Id,
        @FirstName,
        @LastName,
        @Wage,
        @Gender,
        @Role
)