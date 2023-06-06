create procedure ProcDeleteProductDetail
	@ConsumableId int
AS
	DELETE FROM Products
	WHERE ConsumableId= @ConsumableId
GO

Execute ProcDeleteProductDetail 8