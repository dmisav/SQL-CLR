
alter assembly CLRFunctions FROM 'D:\GIT\SQL-CLR\UserDefinedFunctions\UserDefinedFunctions\bin\Release\UserDefinedFunctions.dll'
CREATE TYPE dbo.Point
EXTERNAL NAME [CLRFunctions].[UserDefinedFunctions.Point]


