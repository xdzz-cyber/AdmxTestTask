SELECT TOV.NTOV as itemName, (sum(case when dmz.PR= 1 then KOL end) -
sum(case when dmz.PR= 2 then KOL end)) AS countOfRemainder,
(SUM(case when PR = 1 then CENA end) -
SUM(case when PR = 2 then CENA end)) AS remainingSum
FROM TOV JOIN DMS ON TOV.KTOV = DMS.KTOV JOIN DMZ ON DMZ.NDM = DMS.DmzId
GROUP BY TOV.NTOV ORDER BY TOV.NTOV