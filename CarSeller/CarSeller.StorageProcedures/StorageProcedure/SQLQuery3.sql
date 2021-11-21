CREATE PROCEDURE InsertCar
(@Id INT,
 @Name  NVARCHAR(10),
 @Brand NVARCHAR(10),
 @State INT,
 @SellerId INT)
AS
BEGIN
	INSERT INTO Cars(Id, Name, Brand, State, SellerId)
	VALUES(@Id, @Name, @Brand, @State, @SellerId)
END
GO
