-- Procedure responsável por atualizar o funcionário.
CREATE PROCEDURE spUpdateEmployee
    @Id UNIQUEIDENTIFIER,
    @FirstName VARCHAR(30),
    @LastName VARCHAR(30),
    @Wage MONEY,
    @Gender TINYINT,
    @Role TINYINT
AS
UPDATE [Employee]
SET Id = @Id, 
    FirstName = @FirstName,
    LastName = @LastName,
    Wage = @Wage,
    Gender = @Gender,
    Role = @Role
WHERE Id = @Id
