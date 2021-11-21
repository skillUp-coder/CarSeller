CREATE PROCEDURE InsertSeller
(
	@FirstName NVARCHAR(20),
	@LastName NVARCHAR(20)
)
AS
BEGIN
    INSERT INTO Sellers
	VALUES (@FirstName, @LastName)
END
GO
