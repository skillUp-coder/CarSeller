/****** Object:  StoredProcedure [dbo].[DeleteCar]    Script Date: 11/21/2021 9:09:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[DeleteCar]
(
	@Id INT
)
AS
BEGIN
    DELETE Cars
	WHERE Id = @Id
END
