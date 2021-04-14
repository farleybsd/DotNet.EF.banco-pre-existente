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
