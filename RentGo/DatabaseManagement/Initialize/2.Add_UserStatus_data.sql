
if not exists (select [name] from UserStatus where [name]='Active')
begin
INSERT INTO [dbo].[UserStatus]([Name],[DateCreated]) VALUES ('Active',GETDATE());
end

if not exists (select [name] from UserStatus where [name]='Pending')
begin
INSERT INTO [dbo].[UserStatus]([Name],[DateCreated]) VALUES ('Pending',GETDATE());
end

if not exists (select [name] from UserStatus where [name]='Inactive')
begin
INSERT INTO [dbo].[UserStatus]([Name],[DateCreated]) VALUES ('Inactive',GETDATE());
end

if not exists (select [name] from UserStatus where [name]='Blocked')
begin
INSERT INTO [dbo].[UserStatus]([Name],[DateCreated]) VALUES ('Blocked',GETDATE());
end
