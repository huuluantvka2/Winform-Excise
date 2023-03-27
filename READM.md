Insert into Employees(FullName,Email,Password) VALUES('Admin','admin@aegona.com','123456x@X');
SELECT TOP (1000) [Id]
,[FullName]
,[Email]
,[Password]
FROM [LuanTest].[dbo].[Employees]

SELECT TOP 2 Id FROM Employees
WHERE Email='luanle@aegona.com' And Password = '1233456y@Y';
