SELECT TOP 5
A.first_name,
A.last_name,
COUNT(*) AS TOTAL
FROM actor A
	INNER JOIN film_actor FA ON FA.actor_id = A.actor_id
GROUP BY 
A.first_name,
A.last_name
ORDER BY TOTAL


-- modelo ef 

SELECT
a.*
FROM actor a
	inner join (
SELECT TOP 5
A.actor_id,
COUNT(*) AS TOTAL
FROM actor a
	INNER JOIN film_actor FA ON FA.actor_id = a.actor_id
GROUP BY 
A.actor_id
ORDER BY TOTAL desc) filmes on filmes.actor_id = a.actor_id
