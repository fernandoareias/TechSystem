-- Retorna Todos os funcionarios que possuem dependentes 
CREATE VIEW vw_EmployerDependents AS
    SELECT emp.[Id] AS [ID Employee], emp.[Name] AS [Name Employee], dep.Id AS [ID Dependent], dep.Name AS [Name Dependent] FROM [Employee] emp LEFT JOIN [Dependent] dep ON (emp.Id = dep.EmployeeId)

-- Retorna a lista de funcionario que possuem supervisores
CREATE VIEW vw_EmployeWithSupervisor AS 
    SELECT emp.[Id] AS [ID Employee], emp.[Name] AS [Name Employee], sup.[Name] AS [Name Supervisor] FROM [Employee] emp INNER JOIN [Employee] sup ON (sup.Id = emp.SupervisorId);

-- Retorna a lista de supervisores
CREATE VIEW vw_Supervisors AS
    SELECT sup.[Name] AS [Name Supervisor], SUP.[Id] AS [ID Supervisor] FROM [Employee] emp  RIGHT JOIN [Employee] sup ON (sup.Id = emp.Id) WHERE emp.SupervisorId IS NULL;

-- Retorna todos os funcionarios que trabalham em departamentos
CREATE VIEW vw_EmployerDepartmens AS
    SELECT Emp.[Name]  AS [Employee Name], Emp.[DepartmentId] AS [ID Department] FROM [Employee] Emp INNER JOIN [Department] Dep ON(Emp.DepartmentId = Dep.Id)

