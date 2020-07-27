CREATE TABLE [dbo].[User]
(
    [Name] VARCHAR(50) NOT NULL, 
    [UserName] VARCHAR(50) NOT NULL, 
    [Password] VARCHAR(50) NOT NULL, 
    [Role] VARCHAR(50) NOT NULL, 
    [phone] INT NOT NULL, 
    [Addess] VARCHAR(50) NOT NULL, 
    PRIMARY KEY ([UserName])
)
