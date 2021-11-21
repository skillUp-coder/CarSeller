CREATE PROCEDURE UpdateSeller
(
	@Id INT,
	@FirstName NVARCHAR(20),
	@LastName NVARCHAR(20)
)
AS
BEGIN
	UPDATE Sellers
	SET FirstName = @FirstName, LastName = @LastName
	WHERE Id = @Id
END
GO
