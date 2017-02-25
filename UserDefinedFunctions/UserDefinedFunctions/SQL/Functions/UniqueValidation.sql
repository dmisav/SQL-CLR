alter assembly CLRFunctions FROM 'D:\GIT\SQL-CLR\UserDefinedFunctions\UserDefinedFunctions\bin\Release\UserDefinedFunctions.dll'

go
create function dbo.UniqueValidation
(
@username nvarchar(max)
)
returns bit
as external Name [CLRFunctions].[UserDefinedFunctions.UserDefinedFunctions].[UniqueValidation]