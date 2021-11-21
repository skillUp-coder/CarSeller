/****** Object:  StoredProcedure [dbo].[GetByIdCar]    Script Date: 11/21/2021 8:59:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetByIdCar]
(
	@Id INT
)
AS
BEGIN
    SELECT * FROM Cars car
	JOIN Sellers seller ON car.SellerId = seller.Id
	WHERE car.Id = @Id
END
