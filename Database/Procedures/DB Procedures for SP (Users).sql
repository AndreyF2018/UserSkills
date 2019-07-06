USE [Users_and_skills]
GO
Create procedure AddUser @Name varchar(50), @Login varchar(50), @Password varchar(50)
AS
BEGIN
DECLARE @userId int
DECLARE @userName varchar(50)
DECLARE @userLogin varchar(50)
DECLARE @userPassword varchar(50)
DECLARE @IsCorrect bit
Set @IsCorrect = 1

	if Len(@Password) < 8
	begin
		Select('Минимальная длина пароля 8 символов')
		SET @IsCorrect = 0
	end
	else
	begin 
		DECLARE @CURSOR CURSOR
		SET @CURSOR  = CURSOR SCROLL
		FOR
		SELECT us.userId, us.userName, us.userLogin, us.userPassword
		FROM Users us
		OPEN @CURSOR
		FETCH NEXT FROM @CURSOR into @userId, @userName, @userLogin, @userPassword
		while @@FETCH_STATUS = 0
		BEGIN
			if @userLogin = @Login
			begin
			Select('Логин занят')
				SET @IsCorrect = 0
			end
			FETCH NEXT FROM @CURSOR into @userId, @userName, @userLogin, @userPassword
		END
		CLOSE @CURSOR
		end
	if @IsCorrect = 1
	begin
		Insert into Users
		(userName, userLogin, userPassword)
		VALUES
		(@Name, @Login, @Password)
		Select('Пользователь успешно добавлен')
	end
	END


--drop procedure AddUser
--Exec AddUser 'User 5', 'User_5_login', 1

GO
Create procedure EditUserName @id int, @newName varchar(50)
AS
BEGIN
	UPDATE Users
	SET userName = @newName
	where userId = @id
END

--drop procedure EditNameUser

GO
Create procedure EditUserPassword @id int, @login varchar(50), @oldPassword varchar(50), @newPassword varchar(50)
AS
BEGIN
	DECLARE @status bit
	SET @status = 0
	DECLARE @userId int
	DECLARE @userName varchar(50)
	DECLARE @userPassword varchar(50)
	DECLARE @userLogin varchar (50)
	if LEN(@newPassword) < 8
	begin
		SET @status = 1
		select('Минимальная длина пароля 8 символов')
	end
	else
	begin
		DECLARE @CURSOR CURSOR
		SET @CURSOR  = CURSOR SCROLL
		FOR
		SELECT us.userId, us.userName, us.userLogin, us.userPassword
		FROM Users us
		OPEN @CURSOR
		FETCH NEXT FROM @CURSOR into @userId, @userName, @userLogin, @userPassword
		while @@FETCH_STATUS = 0
		BEGIN
			if @userId = @id
			begin
				if @oldPassword = @userPassword and @login = @userLogin
				begin
					UPDATE Users
					SET userPassword = @newPassword
					where userId = @userId
					select('Пароль успешно изменён')
				end
				else
				begin
					SET @status = 1
					select(-1)
				end
				end
				FETCH NEXT FROM @CURSOR into @userId, @userName, @userLogin, @userPassword
			END
		end
END

--drop procedure EditUserPassword
--EXEC EditUserPassword 5, 'User_5_login', '987654321', '12345678'

GO
CREATE procedure UserAuthentication @login varchar (50), @password varchar (50), @id int output
AS
BEGIN
	SET @id = (select us.userId from Users us where us.userLogin = @login and us.userPassword = @password)
	if @id IS NULL
	begin
		SET @id = -1
	end
	else
		return @id
END

--drop procedure UserAuthentication

--Declare @resultId int
--EXEC UserAuthentication 'User_5_login', '123', @resultId output
--print('Result: ' + cast(@resultId as varchar))

GO
CREATE Procedure GetAllUsers
AS
BEGIN
	select us.*
	from Users us
	return
END

GO
Create Procedure GetUserById @id int
AS
Begin
	select us.userId, us.userLogin, us.userName
	from Users us
	where us.userId = @id
END

GO
Create Procedure GetUserByLogin @login varchar(50)
AS
BEGIN
		select us.*
	from Users us
	where us.userLogin = @login
END