CREATE PROCEDURE GetByIdSeller
(
	@Id INT
)
AS
BEGIN
    SELECT * FROM Sellers seller
	WHERE seller.Id = @Id
END
GO
