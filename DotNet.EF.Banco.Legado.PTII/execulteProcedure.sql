
--
-- Structure for sp total_actors_from_given_category
--
CREATE PROCEDURE total_actors_from_given_category
	@category_name varchar(25),
	@total_actors int OUT
AS
BEGIN
	SET @total_actors = (SELECT count(distinct a.actor_id)
	from dbo.actor a
	  inner join film_actor fa on fa.actor_id = a.actor_id
	  inner join film f on f.film_id = fa.film_id
	  inner join film_category fc on fc.film_id = f.film_id
	  inner join category c on c.category_id = fc.category_id
	where c.name = @category_name);
END



declare @total int 
execute total_actors_from_given_category 'Action' , @total OUT
select @total