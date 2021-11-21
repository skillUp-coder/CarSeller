CREATE PROCEDURE GetByIdPurchase
(
	@Id INT
)
AS
BEGIN
	SELECT purchase.Id, purchase.SellerId, purchase.CarId FROM Purchases purchase
	WHERE purchase.Id = @Id
END
GO
