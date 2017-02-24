sp_configure 'clr enabled', 1
go
reconfigure
go
create assembly CLRFunctions FROM 'D:\GIT\SQL-CLR\UserDefinedFunctions\UserDefinedFunctions\bin\Release\UserDefinedFunctions.dll' 
go
-- for update
--alter assembly CLRFunctions FROM 'D:\GIT\SQL-CLR\UserDefinedFunctions\UserDefinedFunctions\bin\Release\UserDefinedFunctions.dll'