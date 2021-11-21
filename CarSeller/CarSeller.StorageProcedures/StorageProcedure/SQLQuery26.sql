CREATE PROCEDURE UpdatePurchase
(
	@Id INT, 
	@UserId NVARCHAR(20),
	@CarId INT
)
AS
BEGIN
	UPDATE Purchases
	SET UserId = @UserId, CarId = @CarId
	WHERE Id = @Id
END
GO
