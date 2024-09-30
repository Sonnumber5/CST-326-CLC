CREATE DATABASE budgetingdb
GO
USE budgetingdb
GO
CREATE TABLE [expenses] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [name]        NVARCHAR (45)   NULL,
    [price]       DECIMAL (18, 2)    NULL,
    [category]    NVARCHAR (45)   NULL,
    [date]        DATETIME        NULL,
    [description] NVARCHAR (1024) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

