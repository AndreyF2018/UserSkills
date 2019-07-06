CREATE TABLE Users (
	userId int Identity NOT NULL CONSTRAINT PK_Users PRIMARY KEY,
	userName varchar (50) NOT NULL,
	userLogin varchar (50) Not Null,
	userPassword varchar (50) Not null,
)

GO
CREATE TABLE Skills (
	skillId int Identity NOT NULL CONSTRAINT PK_Skills PRIMARY KEY,
	skillTitle varchar (50) NOT NULL,
	skillDescription varchar (50) NOT NULL,

)
GO

CREATE TABLE Relations (
relationID int Identity NOT NULL CONSTRAINT PK_Relations PRIMARY KEY,
userID int NOT NULL,
skil int NOT NULL,
)


Insert into Users
(userName, userLogin, userPassword)
Values
('User 1', 'User_1_login', '12345678'),
('User 2', 'User_2_login', '87654321'),
('User 3', 'User_3_login', 'qwertyui'),
('User 4', 'User_4_login', 'asdfghjk')

Insert into Skills
(skillTitle, skillDescription)
Values
('Программирование', 'Профессиональный навык'),
('Коммуникабельность', 'Личностный навык'),
('Спорт', 'Личностный навык'),
('Лидерство', 'Личностный и профессиональный навык')

