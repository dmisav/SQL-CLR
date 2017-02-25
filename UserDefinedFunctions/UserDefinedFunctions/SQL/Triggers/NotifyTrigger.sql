alter assembly CLRFunctions FROM 
'D:\GIT\SQL-CLR\UserDefinedFunctions\UserDefinedFunctions\bin\Release\UserDefinedFunctions.dll';

create table Users
(
UserName nvarchar(200) NOT NULL,
Pass nvarchar(200) NOT NULL
);
create table UsersAudit
(
UserName nvarchar(200) NOT NULL
);
go

create trigger dbo.trg_i_DWNotify
on dbo.Users after insert
as
external name [CLRFunctions].[UserDefinedFunctions.UserDefinedTriggers].UserNameAudit

-- Insert one user name that is not an e-mail address and one that is
INSERT INTO Users(UserName, Pass) VALUES(N'someone', N'cnffjbeq')
INSERT INTO Users(UserName, Pass) VALUES(N'someone@example.com', N'cnffjbeq')

-- check the Users and UsersAudit tables to see the results of the trigger
select * from Users
select * from UsersAudit
