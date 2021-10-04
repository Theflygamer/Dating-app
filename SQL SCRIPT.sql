use Master
--sætter databasen til single user. får error hvis ikke eksisterer
alter database DatingApp
set SINGLE_USER
with ROLLBACK IMMEDIATE
go
--dropper den hvis den eksisterer. får ikke error
drop database if exists DatingApp
go
--laver den
create database DatingApp
go
use DatingApp
go

set Dateformat dmy

--laver alle vores tabeller, uden foreign keys
create table Account (
accountID int primary key identity(1,1) NOT NULL,
firstName varchar(255),
lastName varchar(255),
[password] varchar(255) NOT NULL,
email varchar(255),
userName varchar(255) NOT NULL,
Birthdate date NOT NULL,
Gender bit NOT NULL,
postnummer int
)
create table City (
postNr int primary key NOT NULL,
City varchar(255) NOT NULL
)
create table Match (
matchID int primary key identity(1,1),
PersonIDLiker int NOT NULL,
PersonIDLikee int NOT NULL,
matchbit bit
)
Create table Chat (
chatID int primary key identity(1,1),
matchID int NOT NULL,
Field nvarchar(255)
)
go
--indsætter alle foreign keys
alter table Account add foreign key (postnummer) references City(PostNr)
alter table [Match] add foreign key (PersonIDLiker) references Account(AccountID)
alter table [Match] add foreign key (PersonIDLikee) references Account(AccountID)
alter table Chat add foreign key (matchID) references Match(matchID)

go

insert into City values 
(2500, 'Valby'),
(1720, 'Kbh V'),
(1240, 'Randers')

go

create procedure dbo.CreateAccount
	@pfirstName varchar(50),
	@plastName varchar(50),
	@ppassword varchar(200),
	@pemail varchar(255),
	@pusername varchar(255),
	@pbirthdate date,
	@pgender bit,
	@ppostnummer int,
	@responseMessage nvarchar(250) OUTPUT
as
begin

begin try
	if exists (select * from Account where userName = @pUsername)
	begin
		set @responseMessage='Already exists'
	end
	else
		begin 
		insert into dbo.Account (firstName,lastName,[password],email,userName,Birthdate,Gender,postnummer)
		values(@pfirstName,@plastName,@ppassword,@pemail,@puserName,@pbirthdate,@pgender,@ppostnummer)
		set @responseMessage='Success'
	end
end try
begin catch
	set @responseMessage=ERROR_MESSAGE()
end catch

end

go

DECLARE @responseMessage NVARCHAR(250)

exec dbo.CreateAccount
@pfirstName = 'Svend',
@plastName = 'Paul',
@ppassword = 'ok',
@pemail = 'Svend@paul.com',
@pusername = 'med',
@pbirthdate = '01-01-1990',
@pGender = 1,
@ppostnummer = 2500,
@responseMessage=@responseMessage OUTPUT

exec dbo.CreateAccount
@pfirstName = 'Mikkel',
@plastName = 'Bikkel',
@ppassword = 'hej',
@pemail = 'mikkel@bikkel.com',
@pusername = 'hej',
@pbirthdate = '01-01-2000',
@pGender = 1,
@ppostnummer = 2500,
@responseMessage=@responseMessage OUTPUT

exec dbo.CreateAccount
@pfirstName = 'Trine',
@plastName = 'Mikkel',
@ppassword = 'wow',
@pemail = 'Trine@bikkel.com',
@pusername = 'dig',
@pbirthdate = '01-01-2010',
@pGender = 1,
@ppostnummer = 2500,
@responseMessage=@responseMessage OUTPUT

exec dbo.CreateAccount
@pfirstName = 'Bo',
@plastName = 'Boesen',
@ppassword = 'slet',
@pemail = 'bo@bikkel.com',
@pusername = 'jeghedderkaj',
@pbirthdate = '01-01-2000',
@pGender = 1,
@ppostnummer = 2500,
@responseMessage=@responseMessage OUTPUT
go

create procedure dbo.SendLike
	@pPersonIDLiker int,
	@pPersonIDLikee int,
	@responseMessage nvarchar(250) OUTPUT
as
begin

begin try
	insert into [Match] (PersonIDLiker, PersonIDLikee) values (@pPersonIDLiker,@pPersonIDLikee) 

	set @responseMessage='Success'
end try
begin catch
	set @responseMessage=ERROR_MESSAGE()
end catch

end
go

DECLARE @responseMessage NVARCHAR(250)

exec dbo.SendLike
@pPersonIDLiker = 1,
@pPersonIDLikee = 2,
@responseMessage=@responseMessage OUTPUT

exec dbo.SendLike
@pPersonIDLiker = 2,
@pPersonIDLikee = 1,
@responseMessage=@responseMessage OUTPUT

exec dbo.SendLike
@pPersonIDLiker = 4,
@pPersonIDLikee = 3,
@responseMessage=@responseMessage OUTPUT

go

create procedure dbo.DeleteAccount

@pAccountID int,

@responseMessage nvarchar(250) OUTPUT
as
begin

begin try
	delete from Match where PersonIDLiker = @pAccountID or PersonIDLikee = @pAccountID
end try
begin catch
	set @responseMessage=ERROR_MESSAGE()
end catch

begin try 

	delete from Account where accountID= @pAccountID
	set @responseMessage='Succes'
end try
begin catch
	set @responseMessage=ERROR_MESSAGE()
end catch

end
go

DECLARE @responseMessage NVARCHAR(250)

exec dbo.DeleteAccount
@pAccountID = 4,
@responseMessage=@responseMessage OUTPUT

go
create procedure dbo.SearchAge
	@pBirthDateStart date,
	@pBirthDateEnd date,
	@responseMessage nvarchar(250) OUTPUT
as
begin

begin try
	select userName, Birthdate, Gender, accountID from Account where Birthdate between @pBirthDateStart and @pBirthDateEnd
	set @responseMessage='Success'
end try
begin catch
	set @responseMessage=ERROR_MESSAGE()
end catch
end
go

create procedure dbo.NoLike
	@pPersonIDLiker int,
	@pPersonIDLikee int,
	@responseMessage nvarchar(250) OUTPUT
as
begin

begin try
	update [Match]
	set matchbit = 0
	where PersonIDLiker = @pPersonIDLiker and PersonIDLikee = @pPersonIDLikee

	set @responseMessage='Success'
end try
begin catch
	set @responseMessage=ERROR_MESSAGE()
end catch

end
go

DECLARE @responseMessage NVARCHAR(250)

exec dbo.NoLike
@pPersonIDLiker = 1,
@pPersonIDLikee = 2,
@responseMessage=@responseMessage OUTPUT
go

create procedure dbo.SeeLikes
	@pPersonIDLikee int,
	@responseMessage nvarchar(250) OUTPUT

as
begin

begin try
	select Account.userName, Account.Birthdate, Account.Gender, Account.accountID
	from Account
	inner join [Match]
	on Account.accountID =[match].PersonIDLiker
	where [Match].PersonIDLikee = @pPersonIDLikee and [Match].matchbit IS NULL
	order by accountID


	set @responseMessage='Success'
end try
begin catch
	set @responseMessage=ERROR_MESSAGE()
end catch

end

go

DECLARE @responseMessage NVARCHAR(250)
exec dbo.SeeLikes
@pPersonIDLikee = 2,
@responseMessage=@responseMessage OUTPUT
go

create procedure dbo.LikeBack
	@pPersonIDLiker int,
	@pPersonIDLikee int,
	@responseMessage nvarchar(250) OUTPUT
as
begin

begin try
	update [Match]
	set matchbit = 1
	where PersonIDLiker = @pPersonIDLiker and PersonIDLikee = @pPersonIDLikee

	set @responseMessage='Success'
end try
begin catch
	set @responseMessage=ERROR_MESSAGE()
end catch

end
go

DECLARE @responseMessage NVARCHAR(250)

exec dbo.LikeBack
@pPersonIDLiker = 2,
@pPersonIDLikee = 1,
@responseMessage=@responseMessage OUTPUT

go
create procedure dbo.Login
	@pusername nvarchar(50),
	@ppassword nvarchar(50),
	@responseMessage nvarchar(250) OUTPUT
as
begin

begin try
	SELECT  accountID
	FROM dbo.Account
	WHERE userName=@pusername AND [Password]=@ppassword
	set @responseMessage='Success'
	/*if exists (select * from Profile where userName = @pusername)
	begin
		select * from Account where password = HASHBYTES('SHA2_512', @ppassword)
		set @responseMessage='Logget ind'
	end
	else
	begin 
		set @responseMessage='Brugernavn/Password er forkert'
	end*/
end try
begin catch
	set @responseMessage='fejl'
end catch

end
go

create procedure dbo.SeeInfo
	@pUID nvarchar(50),
	@responseMessage nvarchar(250) OUTPUT
as
begin

begin try
	SELECT firstName, lastName, HASHBYTES('SHA2_512', password) as [Password], email, userName, Birthdate, Gender, postnummer from Account where accountID = @pUID
	set @responseMessage='Success'
end try
begin catch
	set @responseMessage='fejl'
end catch

end

go

declare @responseMessage nvarchar(250)
exec SeeInfo
@pUID = 2,
@responseMessage=@responseMessage OUTPUT

go


declare @responseMessage nvarchar(250)
exec Login
@pusername = 'Trine',
@ppassword = 'wow',
@responseMessage=@responseMessage OUTPUT
go

create procedure dbo.SeeMatches
	@pUID nvarchar(50),
	@responseMessage nvarchar(250) OUTPUT
as
begin

begin try
	select Account.userName, Account.Birthdate, Account.Gender
	from Account
	inner join [Match]
	on (accountID = PersonIDLiker or accountID = PersonIDLikee)
	where [Match].matchbit = 1 and Account.accountID = @pUID
	set @responseMessage='Success'
end try
begin catch
	set @responseMessage='fejl'
end catch

end

select * from Account
select * from Match