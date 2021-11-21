CREATE PROCEDURE GetByIdCar
(
	@Id INT
)
AS
BEGIN
    SELECT * FROM Cars car
	JOIN Sellers seller ON car.SellerId = seller.Id
	WHERE car.Id = @Id
END
GO
