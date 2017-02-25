

if(object_id(N'[dbo].[UdfPointTable]', 'U') is null)
create table dbo.UdfPointTable (column1 Point)
go

insert into dbo.UdfPointTable (column1) values ('1:2');
insert into dbo.UdfPointTable (column1) values ('-2:3');
insert into dbo.UdfPointTable (column1) values ('-3:-4');

select column1.Quadrant() from dbo.UdfPointTable