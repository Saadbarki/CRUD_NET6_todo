USE [TodoDB]
GO
/****** Object:  StoredProcedure [dbo].[UpdateTodo]    Script Date: 1/19/2023 12:44:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[UpdateTodo]  
	-- Add the parameters for the stored procedure here
	@TodoId int,
	@Name varchar(150),
	@Description varchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	UPDATE TodoTab
	SET NAME=@Name,DESCRIPTION = @Description
	WHERE ID = @TodoId;
END
