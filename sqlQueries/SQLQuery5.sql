insert into DMS
select max(D.KTOV) as KTOV,max(KOL) as KOL, max(CENA) as CENA, max(D.DmzId)
    as DmzId from DMZ join DMS D on DMZ.NDM = D.DmzId join TOV T on D.KTOV = T.KTOV
         where PR = 1 and NDM
 = (select min(NDM) from DMZ join TOV T on D.KTOV = T.KTOV)
or NDM = (select max(NDM) from DMZ join TOV T on D.KTOV = T.KTOV)
         group by NTOV