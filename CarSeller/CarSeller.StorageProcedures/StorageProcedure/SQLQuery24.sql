CREATE PROCEDURE GetAllPurchase
AS
BEGIN
	SELECT purchase.SellerId, purchase.CarId FROM Purchases purchase
END
GO
