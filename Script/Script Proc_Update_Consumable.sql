CREATE PROCEDURE Proc_UpDate_Consumable
(@Id_Consumable int,
@Quantity_Consumable int,
@Stock int output)

AS
BEGIN
	 begin try
        begin transaction
			SET NOCOUNT ON;

			UPDATE tbl_Consumable 
			SET Stock = Stock + @Quantity_Consumable 
			WHERE Id_Consumable = @Id_Consumable;	
			SELECT @Stock = Stock FROM tbl_Consumable WHERE Id_Consumable = @Id_Consumable;
		commit transaction
	end try

	begin catch
        -- Rollback any active or uncommittable transactions before       
        PRINT 'An error occurred in stored procedure Proc_UpDate_Consumable'
        BEGIN
            ROLLBACK TRANSACTION;
        END
        RETURN -1;
    end catch
END

DECLARE @Stock_Actualizado int
EXEC Proc_UpDate_Consumable 1, 20, @Stock_Actualizado output









