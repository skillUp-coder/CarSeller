CREATE PROCEDURE UpdateCar
(
	@Id INT,
	@Name NVARCHAR(20),
	@Brand NVARCHAR(20),
	@State INT,
	@SellerId INT
)
AS
BEGIN
    UPDATE Cars
	SET Name = @Name, Brand = @Brand, State = @State, SellerId = @SellerId
	WHERE Id = @Id
END
GO
