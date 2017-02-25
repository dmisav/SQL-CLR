set statistics time on;

alter assembly CLRFunctions FROM 'D:\GIT\SQL-CLR\UserDefinedFunctions\UserDefinedFunctions\bin\Debug\UserDefinedFunctions.dll'

select * from dbo.SplitString('11,22,33,44', ',');
go 100

select * from dbo.SplitStringCLR('11,22,33,44', ',')
go 100