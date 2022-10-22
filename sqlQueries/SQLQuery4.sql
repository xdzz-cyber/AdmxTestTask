insert into DMZ(NDM, PR)
select iif(count(*) > 0, max(NDM) + 1, 1),
iif(count(case when PR = 1 then 1 end) > count(case when PR = 2 then 1 end) , 2, 1) as PR
FROM DMZ