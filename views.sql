create view roba_sa_jedinicom_mjere(SifraRoba,Naziv,SifraJediniceMjere,OpisJediniceMjere) as
select SifraRoba,Naziv,r.SifraJediniceMjere,OpisJediniceMjere from roba r inner join jedinica_mjere j on r.SifraJediniceMjere=j.SifraJediniceMjere;


create view kalkulacija_osnovno(RedniBroj,PoslovnaGodina,BrojFaktureDobavljaca,Datum,JIB,Naziv,Adresa,PostanskiBroj,NazivMjesto) as
SELECT k.RedniBroj,PoslovnaGodina,BrojFaktureDobavljaca,Datum,p.JIB,p.Naziv,p.Adresa,p.PostanskiBroj,m.NazivMjesto FROM veleprodaja.kalkulacija k inner join stavka_knjige_trgovine_na_veliko s on s.RedniBroj=k.RedniBroj inner join partner p on p.jib=s.jib inner join mjesto m on m.PostanskiBroj=p.PostanskiBroj;

create view kalkulacija_bezPartnera(RedniBroj,PoslovnaGodina,BrojFaktureDobavljaca,Datum,JIB) as 
select k.RedniBroj,PoslovnaGodina,BrojFaktureDobavljaca,Datum,JIB from kalkulacija k inner join stavka_knjige_trgovine_na_veliko s on k.RedniBroj=s.RedniBroj;

create view stavka_kalkulacija_view(RedniBroj,SifraRoba,Kolicina,NabavnaCijena,Rabat,NetoNabavnaCijena,VeleprodajnaCijena,RazlikaUCijeni,NabavnaVrijednost,VeleprodajnaVrijednost)as
select RedniBroj,SifraRoba,Kolicina,NabavnaCijena,Rabat,NabavnaCijena-NabavnaCijena*Rabat/100 as NetoNabavnaCijena,VeleprodajnaCijena, VeleprodajnaCijena-(NabavnaCijena-NabavnaCijena*Rabat) as RazlikaUCijeni, Kolicina*(NabavnaCijena-NabavnaCijena*Rabat/100) as NabavnaVrijednost,Kolicina*(VeleprodajnaCijena) as VeleprodajnaVrijednost from veleprodaja.stavka_kalkulacije;

create view stavka_kalkulacija_view_detaljno(RedniBroj,SifraRoba,Naziv,SifraJediniceMjere,OpisJediniceMjere,Kolicina,NabavnaCijena,Rabat,NetoNabavnaCijena,VeleprodajnaCijena,RazlikaUCijeni,NabavnaVrijednost,VeleprodajnaVrijednost)as
select RedniBroj,sk.SifraRoba,Naziv,jm.SifraJediniceMjere,OpisJediniceMjere,Kolicina,NabavnaCijena,Rabat,NabavnaCijena-NabavnaCijena*Rabat/100 as NetoNabavnaCijena,VeleprodajnaCijena, VeleprodajnaCijena-(NabavnaCijena-NabavnaCijena*Rabat) as RazlikaUCijeni, Kolicina*(NabavnaCijena-NabavnaCijena*Rabat/100) as NabavnaVrijednost,Kolicina*(VeleprodajnaCijena) as VeleprodajnaVrijednost from veleprodaja.stavka_kalkulacije sk inner join veleprodaja.roba v on sk.SifraRoba=v.SifraRoba inner join veleprodaja.jedinica_mjere jm on v.SifraJediniceMjere=jm.SifraJediniceMjere;

delimiter $$
create procedure iznosKalkulacije (in rb int, out veleprodajniIznos double,out nabavniIznos double, out razlikaUCijeni double)
begin 
set nabavniIznos=0.0;
set veleprodajniIznos=0.0;
select sum(VeleprodajnaVrijednost) into veleprodajniIznos from stavka_kalkulacija_view where RedniBroj=rb;
select sum(NabavnaVrijednost) into nabavniIznos from stavka_kalkulacija_view where RedniBroj=rb;
set razlikaUCijeni=veleprodajniIznos-nabavniIznos;
end $$
delimiter ;

insert into knjiga_trgovine_na_veliko values(2016);
/*
delimiter $$
create trigger stavka_kalkulacije_insert_trigger before insert on stavka_kalkulacije
for each row
begin
if (select exists(select * from stavka_kalkulacije s where s.RedniBroj=new.RedniBroj and s.SifraRoba=new.SifraRoba)) then

else

end if;
end $$
delimiter ;


-- drop view kalkulacija_osnovno;
-- drop view kalkulacija_bezPartnera;
*/
