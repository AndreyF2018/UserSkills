---Skills
USE [Users_and_skills]

GO
CREATE Procedure GetUserSkills @id int
AS 
BEGIN
		create table SkillsTemp(
		skillIdTemp int NOT NULL,
			skillTitleTemp varchar (50) NOT NULL,
			skillDescriptionTemp varchar (50) NOT NULL,
			)
		DECLARE @relationId int
		DECLARE @userId int
		DECLARE @skillId int
		DECLARE @CURSOR CURSOR
		SET @CURSOR  = CURSOR SCROLL
		FOR
		SELECT rel.relationID, rel.userId, rel.skilId 
		FROM Relations rel
		OPEN @CURSOR
		FETCH NEXT FROM @CURSOR into @relationId, @userId, @skillId
		while @@FETCH_STATUS = 0
		BEGIN
			if @userId = @id
			begin
				insert into SkillsTemp select s.* from Skills s where s.skillId = @skillId
			end
			FETCH NEXT FROM @CURSOR into @relationId, @userId, @skillId
		END
		select st.*
		from SkillsTemp st
		drop table SkillsTemp
END

--drop procedure GetUserSkills

GO
Create procedure GetAllSkills
AS
BEGIN
	select s.*
	from Skills  s
END

GO
Create procedure AddSkill @title varchar (50), @description varchar (50)
AS
BEGIN
DECLARE @isCorrect bit
DECLARE @skillId int
DECLARE @skillTitle varchar(50)
DECLARE @skillDescription varchar (50)
SET @isCorrect = 0
DECLARE @CURSOR CURSOR
SET @CURSOR  = CURSOR SCROLL
FOR
SELECT s.skillId, s.skillTitle, s.skillDescription
FROM Skills s
OPEN @CURSOR
FETCH NEXT FROM @CURSOR into @skillId, @skillTitle, @skillDescription
while @@FETCH_STATUS = 0
BEGIN
if @title = @skillTitle
begin	
	SET @isCorrect = 1
	Select('Ќавык с таким названием уже есть, используйте поиск')
end
FETCH NEXT FROM @CURSOR into @skillId, @skillTitle, @skillDescription
END
if @isCorrect = 0
begin
	INSERT INTO Skills
	(skillTitle, skillDescription)
	VALUES
	(@title, @description)
	Select ('Ќавык успешно добавлен')
end
END

GO
Create procedure AssignSkill @assignedUserId int, @assignedSkillId int
AS
BEGIN
DECLARE @relationId int
DECLARE @userId int
DECLARE @skillId int

DECLARE @isAssigned bit
SET @isAssigned = 0
DECLARE @CURSOR CURSOR
SET @CURSOR  = CURSOR SCROLL
FOR
SELECT rel.relationID, rel.userId, rel.skilId 
FROM Relations rel
OPEN @CURSOR
FETCH NEXT FROM @CURSOR into @relationId, @userId, @skillId
while @@FETCH_STATUS = 0
BEGIN
if @userId = @assignedUserId and @skillId = @assignedSkillId
begin
	SET @isAssigned = 1
end
FETCH NEXT FROM @CURSOR into @relationId, @userId, @skillId
END
if @isAssigned = 0
begin
	INSERT INTO Relations
	(userId, skilId)
	VALUES
	(@assignedUserId, @assignedSkillId)
	select ('Ќавык успешно присвоен')
end
else
begin
select('Ётот навык уже присвоен этому пользователю')
end	
END

GO
Create procedure DeleteUserSkill @deletedUserId int, @deletedSkillId int
AS
BEGIN
DECLARE @relationId int
DECLARE @userId int
DECLARE @skillId int

DECLARE @isFound bit
SET @isFound = 0
DECLARE @CURSOR CURSOR
SET @CURSOR  = CURSOR SCROLL
FOR
SELECT rel.relationID, rel.userId, rel.skilId 
FROM Relations rel
OPEN @CURSOR
FETCH NEXT FROM @CURSOR into @relationId, @userId, @skillId
while @@FETCH_STATUS = 0
BEGIN
	if @userId = @deletedUserId and @skillId = @deletedSkillId
begin
	SET @isFound = 1
end
FETCH NEXT FROM @CURSOR into @relationId, @userId, @skillId
END
if @isFound = 1
begin
	DELETE FROM Relations 
	where userId = @userId and skilId = @skillId
	select ('”даление прошло успешно')
end
else
begin
	select('«апрашиваемого навыка у пользовател€ не найдено')
end
END

GO
Create procedure SearchSkill @title varchar (50)
AS
BEGIN
select s.*
from Skills s
where s.skillTitle = @title
END