USE [TodoDB]
GO
/****** Object:  StoredProcedure [dbo].[DeleteTodoById]    Script Date: 1/19/2023 12:44:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[DeleteTodoById]  
	-- Add the parameters for the stored procedure here
	@TodoId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DELETE FROM TodoTab
	WHERE ID = @TodoId;
END
