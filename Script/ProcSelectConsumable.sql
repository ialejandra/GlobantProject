create procedure ProcSelectConsumable(
	@ConsumableId int = 0
)
as
if @ConsumableId > 0
	select * from Consumables where ConsumableId =@ConsumableId
else
	select * from Consumables order by Title

Exec ProcSelectConsumable 8