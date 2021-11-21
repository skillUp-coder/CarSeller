CREATE PROCEDURE GetAllCars
AS
BEGIN
    SELECT car.Name, car.Brand, car.State FROM Cars car
END
GO
