IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'UserLogin')
DROP PROCEDURE UserLogin
GO

CREATE PROCEDURE UserLogin 
@Login nvarchar(255),
@Password nvarchar(255)
AS
SELECT TOP 1 Id, Role from Users Where Login = @Login and Password = @Password
GO


IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'CheckLogin')
DROP PROCEDURE CheckLogin
GO

CREATE PROCEDURE CheckLogin
@Login nvarchar(255)
AS 
SELECT * from Users where Login = @Login
GO


IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'CheckEmail')
DROP PROCEDURE CheckEmail
GO


CREATE PROCEDURE CheckEmail
@Email nvarchar(255)
AS 
SELECT * from Users where Email = @Email
GO


IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'UserSignUp')
DROP PROCEDURE UserSignUp
GO

CREATE PROCEDURE UserSignUp
@Name nvarchar(255),
@Surname nvarchar(255),
@Phone nvarchar(255),
@City nvarchar(255),
@Email nvarchar(255),
@Login nvarchar(255),
@Password nvarchar(255),
@Role nvarchar(255),
@IsBanned bit,
@IsDeleted bit
as
insert into Users(Name, Surname, Phone, City, Email, Login, Password, Role, IsBanned, IsDeleted, DateCreated, BirthDate)
values(@Name, @Surname, @Phone, @City, @Email, @Login, @Password, @Role, @IsBanned, @IsDeleted, GETDATE(), GETDATE())

select Id, DateCreated, Email, IsBanned, Login, Password from users where Login = @Login
go


IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetConversations')
DROP PROCEDURE GetConversations
GO

create procedure GetConversations 
@UserId int
as
select mi.Id, mi.LastMessageBody, mi.LastMessageDate, mi.UserId,
mi.UserImage, mi.UserLogin, mi.UserName, mi.UserSurname
from (select Conversations.Id, max(Messages.DateCreated) as Date
from UserEntityConversationEntities
inner join Conversations on UserEntityConversationEntities.ConversationEntity_Id = Conversations.Id
inner join Messages on Conversations.Id = Messages.Conversation_Id
inner join Users on Messages.User_Id = Users.Id
where UserEntityConversationEntities.UserEntity_Id = @UserId group by Conversations.Id) as mm
inner join
(select Conversations.Id, Messages.Body as LastMessageBody, Messages.DateCreated as LastMessageDate ,
Users.ProfileImageUrl as UserImage, Users.Login as UserLogin, Users.Name as UserName, Users.Surname as UserSurname,
Users.Id as UserId
from UserEntityConversationEntities
inner join Conversations on UserEntityConversationEntities.ConversationEntity_Id = Conversations.Id
inner join Messages on Conversations.Id = Messages.Conversation_Id
inner join Users on UserEntityConversationEntities.UserEntity_Id = Users.Id
where UserEntityConversationEntities.UserEntity_Id != @UserId) as mi
on mm.Id = mi.Id and mm.Date = mi.LastMessageDate
go


IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetConversation')
DROP PROCEDURE GetConversation
GO

create procedure GetConversation
@UserToId int,
@UserFromId int
as
select uc1.ConversationEntity_Id from (select * from UserEntityConversationEntities where UserEntity_Id = @UserToId) as uc1
inner join 
(select * from UserEntityConversationEntities where UserEntity_Id = @UserFromId) as uc2
on uc1.ConversationEntity_Id = uc2.ConversationEntity_Id
go


IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetConMessages')
DROP PROCEDURE GetConMessages
GO


create procedure GetConMessages
@ConversationId int
as 
select Messages.Body, Messages.DateCreated, Users.Login, Users.Name, Users.ProfileImageUrl, Users.Surname from Messages 
inner join Users on Messages.User_Id = Users.Id
where Messages.Conversation_Id = @ConversationId order by Messages.DateCreated
go


IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'CreatingConversation')
DROP PROCEDURE CreatingConversation
GO

create procedure CreatingConversation
@IsDeleted bit,
@UserFromId int,
@UserToId int
as
declare @IdentityOutput table ( ID int )
declare @IdentityValue int

INSERT into Conversations(IsDeleted, DateCreated)
  OUTPUT inserted.Id into @IdentityOutput
  VALUES(@IsDeleted, GETDATE ( ))

select @IdentityValue = (select top 1 ID from @IdentityOutput)

insert into UserEntityConversationEntities(ConversationEntity_Id, UserEntity_Id)
values(@IdentityValue, @UserFromId), (@IdentityValue, @UserToId)

select @IdentityValue
go


IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'PostMessage')
DROP PROCEDURE PostMessage
GO

create procedure PostMessage
@UserId int,
@ConversationId int,
@Body nvarchar(255),
@IsDeleted bit
as

declare @IdentityOutput table ( ID int )
declare @IdentityValue int

insert into Messages(Body, DateCreated, IsDeleted, User_Id, Conversation_Id)
  OUTPUT inserted.Id into @IdentityOutput
values(@Body, GETDATE(), @IsDeleted, @UserId, @ConversationId)

select @IdentityValue = (select top 1 ID from @IdentityOutput)

select Messages.Body, Messages.DateCreated, Users.Login, Users.Name, Users.Surname, Users.ProfileImageUrl from Messages inner join Users on Messages.User_Id = Users.Id
where Messages.Id = @IdentityValue
go



IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'DeleteFeed')
DROP PROCEDURE DeleteFeed
GO

create procedure DeleteFeed
@FeedId int 
as 

delete from FeedMessages where Id = @FeedId

go


IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetFeeds')
DROP PROCEDURE GetFeeds
GO

create procedure GetFeeds
@UserId int
as 

select FeedMessages.Id, FeedMessages.DateCreated, Users.Login, FeedMessages.FeedText, FeedMessages.WasEdited,
Users.Name, Users.Surname, Users.ProfileImageUrl, Users.Id as UserId
from FeedMessages inner join Users on FeedMessages.FromUser_Id = Users.Id
where FeedMessages.ToUser_Id = @UserId

go



IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'UpdateFeed')
DROP PROCEDURE UpdateFeed
GO

create procedure UpdateFeed 
@FeedId int,
@FeedText nvarchar(255)
as

update FeedMessages set FeedText = @FeedText, WasEdited = 1 where Id = @FeedId

go


IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'PostFeed')
DROP PROCEDURE PostFeed
GO

create procedure PostFeed
@UserFromId int,
@UserToId int,
@WasEdited bit,
@FeedText nvarchar(255),
@IsDeleted bit
as

declare @IdentityOutput table ( ID int )
declare @IdentityValue int

insert into FeedMessages(DateCreated, FeedText, FromUser_Id, IsDeleted, WasEdited, ToUser_Id)
  OUTPUT inserted.Id into @IdentityOutput
values(GETDATE(), @FeedText, @UserFromId, @IsDeleted, @WasEdited, @UserToId)

select @IdentityValue = (select top 1 ID from @IdentityOutput)

select FeedMessages.Id, FeedMessages.DateCreated, Users.Login, FeedMessages.FeedText, FeedMessages.WasEdited,
Users.Name, Users.Surname, Users.ProfileImageUrl, Users.Id as UserId from FeedMessages inner join Users on FeedMessages.FromUser_Id = Users.Id
where FeedMessages.Id = @IdentityValue

go



IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'BanUser')
DROP PROCEDURE BanUser
GO

create procedure BanUser
@UserId int 
as 

update Users set IsBanned = (IsBanned ^ 1) where Users.Id = @UserId

go


IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'EditPassword')
DROP PROCEDURE EditPassword
GO

create procedure EditPassword
@UserId int,
@Password nvarchar(255)
as

update Users set Password = @Password where Users.Id = @UserId

go


IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetAllUsers')
DROP PROCEDURE GetAllUsers
GO

create procedure GetAllUsers
as

select Id, FacebookLink, Login, BirthDate, City, DateCreated, Email, IsBanned, Name, Password, Phone, Position, ProfileImageUrl,
Role, Surname, TwitterLink, WebsiteLink from Users

go


IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetByLogin')
DROP PROCEDURE GetByLogin
GO

create procedure GetByLogin
@Login nvarchar(255)
as

select Id, FacebookLink, Login, BirthDate, City, DateCreated, Email, IsBanned, Name, Password, Phone, Position, ProfileImageUrl,
Role, Surname, TwitterLink, WebsiteLink from Users where Login = @Login

go



IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'IsBanned')
DROP PROCEDURE IsBanned
GO

create procedure IsBanned
@Login nvarchar(255)
as

select Id, DateCreated, Email, IsBanned, Login, Password from Users where Login = @Login

go


IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'UpdateUser')
DROP PROCEDURE UpdateUser
GO

create procedure UpdateUser
@UserId int,
@Name nvarchar(255),
@Surname nvarchar(255),
@Phone nvarchar(255),
@Position nvarchar(255),
@City nvarchar(255),
@WebsiteLink nvarchar(255),
@FacebookLink nvarchar(255),
@TwitterLink nvarchar(255)
as

update Users set Name = @Name, Surname = @Surname, Phone = @Phone, Position = @Position, City = @City, WebsiteLink = @WebsiteLink, FacebookLink = @FacebookLink, TwitterLink = @TwitterLink
where Id = @UserId

go


IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetUserInfoSignUp')
DROP PROCEDURE GetUserInfoSignUp
GO

CREATE PROCEDURE GetUserInfoSignUp
@Login nvarchar(255)
as
select Id, DateCreated, Email, IsBanned, Login, Password from users where Login = @Login
go


IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'LastConvMessage')
DROP PROCEDURE LastConvMessage
GO

CREATE procedure LastConvMessage
@UserId int,
@ConversationId int
as

select top 1 Messages.Body, Messages.DateCreated, Users.Login, Users.Name, Users.Surname, Users.ProfileImageUrl from Messages inner join Users on Messages.User_Id = Users.Id
where Messages.User_Id = @UserId and Messages.Conversation_Id = @ConversationId order by Messages.DateCreated desc

go


IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'LastFeedMessage')
DROP PROCEDURE LastFeedMessage
GO

CREATE procedure LastFeedMessage
@UserId int
as

select FeedMessages.Id, FeedMessages.DateCreated, Users.Login, FeedMessages.FeedText, FeedMessages.WasEdited,
Users.Name, Users.Surname, Users.ProfileImageUrl, Users.Id as UserId 
from FeedMessages inner join Users on FeedMessages.FromUser_Id = Users.Id
where FeedMessages.ToUser_Id = @UserId order by FeedMessages.DateCreated desc

go