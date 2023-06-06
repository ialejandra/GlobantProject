create procedure ProcUpdateUsers
	@Id int,
	@DocumentNumber int,
	@TypeUserId int,
	@Title varchar(30),
	@Lastname varchar(30),
	@Phonenumber bigint,
	@Birthday date,
	@Address varchar(70)

AS
UPDATE Users
SET 

TypeUserId = @TypeUserId,
Title = @Title,
Lastname = @Lastname,
Phonenumber= @Phonenumber,
Birthday = @Birthday,
Address = @Address

OUTPUT 
		inserted.Id,
		inserted.DocumentNumber,
		inserted.TypeUserId,
		deleted.Title,
		inserted.Title,
		deleted.Lastname,
		inserted.Lastname,
		deleted.Phonenumber,
		inserted.Phonenumber,
		deleted.Birthday,
		inserted.Birthday,
		deleted.Address,
		inserted.Address

WHERE DocumentNumber = @DocumentNumber

Exec ProcUpdateUsers 3,1017212413,1,'Ingrid Alejandra','Loaiza Vasquez ',3197319190,'01/09/1993','CR 15 # 46-92'

