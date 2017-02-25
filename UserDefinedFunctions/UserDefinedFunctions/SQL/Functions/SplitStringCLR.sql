CREATE FUNCTION [dbo].SplitStringCLR(@text [nvarchar](max), @delimiter [nchar](1))
RETURNS TABLE (
part nvarchar(max),
ID_ODER int
) WITH EXECUTE AS CALLER
AS 
EXTERNAL NAME CLRFunctions.[UserDefinedFunctions.UserDefinedFunctions].SplitString
--- assembly name . namespace name .class name . function name