set statistics time on;

select * from dbo.SplitString('11,22,33,44', ',');
go 100

select * from dbo.SplitStringCLR('11,22,33,44', ',')
go 100