CREATE DATABASE budgetingdb
GO
USE budgetingdb
GO
DROP TABLE expenses;
GO
CREATE TABLE [expenses] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [name]        NVARCHAR (45)                   NOT NULL,
    [price]       DECIMAL (18, 2)                 NOT NULL,
    [category]    NVARCHAR (45)                   NOT NULL,
    [date]        DATETIME                        NOT NULL,
    [description] NVARCHAR (1024)                 NULL,
    [essential]   BIT                             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
CREATE TABLE [budgets] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [value]       DECIMAL (18, 2)                 NOT NULL,
    [date]        DATETIME                        NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

