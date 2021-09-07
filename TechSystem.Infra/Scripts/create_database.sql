

-- Cria o BD
CREATE DATABASE [TechSystem];

-- Seta o BD
USE [TechSystem];

-- Cria a tabela dos funcionários.
CREATE TABLE [Employee]
(
    [Id] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
    [FirstName] VARCHAR(30) NOT NULL,
    [LastName] VARCHAR(30) NOT NULL,
    [Wage] MONEY NOT NULL,
    [Gender] TINYINT NOT NULL,
    [Role] TINYINT NOT NULL
);
GO

-- Cria a tabela dos dependents
CREATE TABLE [Dependents]
(
    [Id] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
    [EmployeeId] UNIQUEIDENTIFIER NOT NULL,
    [FirstName] VARCHAR(30) NOT NULL,
    [LastName] VARCHAR(30) NOT NULL,

    CONSTRAINT [Dependents_Employee_Id] FOREIGN KEY ([EmployeeId]) REFERENCES [Employee]([Id])
);
GO