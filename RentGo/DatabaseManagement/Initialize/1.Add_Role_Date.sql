
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
