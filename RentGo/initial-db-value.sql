USE RentGo;
GO
if not exists (select [name] from AspNetRoles where name='Admin')
begin
INSERT INTO [dbo].[AspNetRoles]([Id],[ConcurrencyStamp],[Name],[NormalizedName]) VALUES (1,NEWID(),'Admin','ADMIN');
end

if not exists (select [name] from AspNetRoles where name='User')
begin
INSERT INTO [dbo].[AspNetRoles]([Id],[ConcurrencyStamp],[Name],[NormalizedName]) VALUES (2, NEWID(),'User','USER');
end

if not exists (select [name] from AspNetRoles where name='Partner')
begin
INSERT INTO [dbo].[AspNetRoles]([Id],[ConcurrencyStamp],[Name],[NormalizedName]) VALUES (3, NEWID(),'Partner','PARTNER');
end



if not exists (select [name] from UserStatus where [name]='Active')
begin
INSERT INTO [dbo].[UserStatus]([Id],[Name],[DateCreated]) VALUES (1,'Active',GETDATE());
end

if not exists (select [name] from UserStatus where [name]='Pending')
begin
INSERT INTO [dbo].[UserStatus]([Id],[Name],[DateCreated]) VALUES (2,'Pending',GETDATE());
end

if not exists (select [name] from UserStatus where [name]='Inactive')
begin
INSERT INTO [dbo].[UserStatus]([Id],[Name],[DateCreated]) VALUES (3,'Inactive',GETDATE());
end

if not exists (select [name] from UserStatus where [name]='Blocked')
begin
INSERT INTO [dbo].[UserStatus]([Id],[Name],[DateCreated]) VALUES (4,'Blocked',GETDATE());
end
