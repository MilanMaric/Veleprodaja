create view roba_sa_jedinicom_mjere(SifraRoba,Naziv,SifraJediniceMjere,OpisJediniceMjere) as
select SifraRoba,Naziv,r.SifraJediniceMjere,OpisJediniceMjere from roba r inner join jedinica_mjere j on r.SifraJediniceMjere=j.SifraJediniceMjere;


