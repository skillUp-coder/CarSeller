CREATE PROCEDURE InsertPurchase
(
	@UserId NVARCHAR(100),
	@CarId INT
)
AS
BEGIN
	INSERT INTO Purchases
	VALUES(@UserId, @CarId)
END
GO
