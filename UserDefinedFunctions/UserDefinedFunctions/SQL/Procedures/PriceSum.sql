
alter assembly CLRFunctions FROM 'D:\GIT\SQL-CLR\UserDefinedFunctions\UserDefinedFunctions\bin\Release\UserDefinedFunctions.dll';
go
create procedure PriceSum (@sum int output)  
as external name [CLRFunctions].[UserDefinedFunctions.UserDefinedStoredProcedures].PriceSum  
