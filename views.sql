create view roba_sa_jedinicom_mjere(SifraRoba,Naziv,SifraJediniceMjere,OpisJediniceMjere) as
select SifraRoba,Naziv,r.SifraJediniceMjere,OpisJediniceMjere from roba r inner join jedinica_mjere j on r.SifraJediniceMjere=j.SifraJediniceMjere;


create view kalkulacija_osnovno(RedniBroj,PoslovnaGodina,JIB,Datum) as
SELECT k.RedniBroj,PoslovnaGodina,JIB,Datum FROM veleprodaja.kalkulacija k inner join stavka_knjige_trgovine_na_veliko s on s.RedniBroj=k.RedniBroj;

