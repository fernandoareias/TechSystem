
CREATE DATABASE [BOBTech]

USE [BOBTech]

CREATE TABLE [Employee](
    [Id] UNIQUEIDENTIFIER NOT NULL,
    [Name] NVARCHAR(80) NOT NULL,
    [Wage] FLOAT NOT NULL,
    [Gender] CHAR(2) NOT NULL CHECK(Gender IN('F', 'M')),
    [SupervisorId] UNIQUEIDENTIFIER,
    [DepartmentId] UNIQUEIDENTIFIER,

    CONSTRAINT [PK_Employee] PRIMARY KEY([Id]),
    CONSTRAINT [FK_Employee_Supervisor] FOREIGN KEY ([SupervisorId]) REFERENCES [Employee]([Id]) ON DELETE NO ACTION,
);
GO

CREATE TABLE [Dependent](
    [Id] UNIQUEIDENTIFIER NOT NULL,
    [Name] VARCHAR(80) NOT NULL,
    [EmployeeId] UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT [PK_Dependent] PRIMARY KEY([Id]),
    CONSTRAINT [FK_Dependent_Employee] FOREIGN KEY([EmployeeId]) REFERENCES [Employee]([Id]) ON DELETE CASCADE
);
GO 

CREATE TABLE [Department](
    [Id] UNIQUEIDENTIFIER NOT NULL,
    [Budget] FLOAT NOT NULL,
    [SupervisorId] UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT [PK_Department] PRIMARY KEY([Id]),
    CONSTRAINT [FK_Department_Supervisor] FOREIGN KEY([SupervisorId]) REFERENCES [Employee]([Id]) ON DELETE NO ACTION
);
GO 

CREATE TABLE [Project](
    [Id] UNIQUEIDENTIFIER NOT NULL,
    [Name] VARCHAR(80) NOT NULL,
    [InitialDate] DATETIME NOT NULL DEFAULT(GETDATE()),

    CONSTRAINT [PK_Project] PRIMARY KEY([Id])

);

GO 

CREATE TABLE [DepartmentHasProject](
    [DepartmentId] UNIQUEIDENTIFIER NOT NULL,
    [ProjectId] UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT [PK_DepartmentHasProject] PRIMARY KEY([DepartmentId], [ProjectId]),
    CONSTRAINT [FK_DepartmentHasProject_Department] FOREIGN KEY([DepartmentId]) REFERENCES [Department]([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_DepartmentHasProject_Project] FOREIGN KEY([ProjectId]) REFERENCES [Project]([Id]) ON DELETE CASCADE 
);
GO 

CREATE TABLE [ProjectMinutes](
    [Id] UNIQUEIDENTIFIER NOT NULL,
    [Minutes] NVARCHAR(120) NOT NULL,
    [ProjectId] UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT [PK_Minutes_Project] PRIMARY KEY([Id]),
    CONSTRAINT [FK_Minutes_Project] FOREIGN KEY([ProjectId]) REFERENCES [Project]([Id]) ON DELETE CASCADE

);
GO 

CREATE TABLE [ProjectSteps](
    [Id] UNIQUEIDENTIFIER NOT NULL,
    [Step] VARCHAR(45) NOT NULL,
    [ProjectId] UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT [PK_ProjectSteps] PRIMARY KEY([Id]),
    CONSTRAINT [FK_ProjectSteps_Project] FOREIGN KEY([ProjectId]) REFERENCES [Project]([Id]) ON DELETE CASCADE

);
GO 

CREATE TABLE [EmployeeHasProject](
    [EmployeeId] UNIQUEIDENTIFIER NOT NULL,
    [DepartmentId] UNIQUEIDENTIFIER NOT NULL,
    [ProjectId] UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT [PK_EmployeeHasProject] PRIMARY KEY([EmployeeId],[DepartmentId],[ProjectId]),
    CONSTRAINT [FK_EmployeeHasProject_Employee] FOREIGN KEY([EmployeeId]) REFERENCES [Employee]([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_EmployeeHasProject_Department] FOREIGN KEY([DepartmentId]) REFERENCES [Department]([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_EmployeeHasProject_Project] FOREIGN KEY([ProjectId]) REFERENCES [Project]([Id]) ON DELETE CASCADE

);
GO 