select distinct NTOV, sum(KOL) as totalCount, sum(CENA)
    as totalSum
from TOV join DMS D on TOV.KTOV = D.KTOV join DMZ D2 on D2.NDM = D.DmzId
WHERE DDM = '2014-01-05' group by NTOV ORDER BY totalSum DESC