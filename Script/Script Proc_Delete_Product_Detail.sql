create procedure Proc_Delete_Product_Detail
	@Id_Consumable int
AS
	DELETE FROM tbl_Product_Detail 
	WHERE Id_Consumable= @Id_Consumable
GO

Execute Proc_Delete_Product_Detail 1