CREATE PROCEDURE GetAllSeller
AS
BEGIN
	SELECT seller.FirstName, seller.LastName  FROM Sellers seller
END
GO
