CREATE PROCEDURE DeletePurchase
(
	@Id INT
)
AS
BEGIN
    DELETE Purchases
	WHERE Id = @Id
END
GO
