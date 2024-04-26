DELETE FROM Categories
WHERE name IN (
    SELECT name
    FROM Categories
    GROUP BY name
    HAVING COUNT(*) > 1
);

select * from course
order by name
select * from Categories
order by name

delete from course
where id >= 180