/****** Object:  StoredProcedure [dbo].[InsertCar]    Script Date: 11/21/2021 8:21:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[InsertCar]
(@Name  NVARCHAR(10),
 @Brand NVARCHAR(10),
 @State INT,
 @SellerId INT)
AS
BEGIN
	INSERT INTO Cars(Name, Brand, State, SellerId)
	VALUES(@Name, @Brand, @State, @SellerId)
END
