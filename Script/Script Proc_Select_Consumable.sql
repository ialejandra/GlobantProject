create procedure Proc_Select_Consumable(
	@Id_Consumable int = 0
)
as
if @Id_Consumable > 0
	select * from tbl_Consumable where Id_Consumable =@Id_Consumable
else
	select * from tbl_Consumable order by Title

Exec Proc_Select_Consumable 2