create view roba_sa_jedinicom_mjere(SifraRoba,Naziv,SifraJediniceMjere,OpisJediniceMjere) as
select SifraRoba,Naziv,r.SifraJediniceMjere,OpisJediniceMjere from roba r inner join jedinica_mjere j on r.SifraJediniceMjere=j.SifraJediniceMjere;


create view kalkulacija_osnovno(RedniBroj,PoslovnaGodina,BrojFaktureDobavljaca,Datum,JIB,Naziv,Adresa,PostanskiBroj,NazivMjesto) as
SELECT k.RedniBroj,PoslovnaGodina,BrojFaktureDobavljaca,Datum,p.JIB,p.Naziv,p.Adresa,p.PostanskiBroj,m.NazivMjesto FROM veleprodaja.kalkulacija k inner join stavka_knjige_trgovine_na_veliko s on s.RedniBroj=k.RedniBroj inner join partner p on p.jib=s.jib inner join mjesto m on m.PostanskiBroj=p.PostanskiBroj;

create view kalkulacija_bezPartnera(RedniBroj,PoslovnaGodina,BrojFaktureDobavljaca,Datum,JIB) as 
select k.RedniBroj,PoslovnaGodina,BrojFaktureDobavljaca,Datum,JIB from kalkulacija k inner join stavka_knjige_trgovine_na_veliko s on k.RedniBroj=s.RedniBroj;

-- drop view kalkulacija_osnovno;
-- drop view kalkulacija_bezPartnera;