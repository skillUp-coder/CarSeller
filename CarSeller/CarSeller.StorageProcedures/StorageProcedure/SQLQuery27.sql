/****** Object:  StoredProcedure [dbo].[GetByIdPurchase]    Script Date: 11/21/2021 9:20:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetByIdPurchase]
(
	@Id INT
)
AS
BEGIN
	SELECT purchase.Id, purchase.CarId FROM Purchases purchase
	WHERE purchase.Id = @Id
END
