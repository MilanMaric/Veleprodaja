
drop view if exists roba_sa_jedinicom_mjere;
create view roba_sa_jedinicom_mjere(SifraRoba,Naziv,SifraJediniceMjere,OpisJediniceMjere) as
select SifraRoba,Naziv,r.SifraJediniceMjere,OpisJediniceMjere from roba r inner join jedinica_mjere j on r.SifraJediniceMjere=j.SifraJediniceMjere;


drop view if exists kalkulacija_osnovno;
create view kalkulacija_osnovno(RedniBroj,PoslovnaGodina,BrojFaktureDobavljaca,Datum,JIB,Naziv,Adresa,PostanskiBroj,NazivMjesto) as
SELECT k.RedniBroj,PoslovnaGodina,BrojFaktureDobavljaca,Datum,p.JIB,p.Naziv,p.Adresa,p.PostanskiBroj,m.NazivMjesto FROM veleprodaja.kalkulacija k inner join stavka_knjige_trgovine_na_veliko s on s.RedniBroj=k.RedniBroj inner join partner p on p.jib=s.jib inner join mjesto m on m.PostanskiBroj=p.PostanskiBroj;

drop view if exists otpremnica_osnovno;
create view otpremnica_osnovno(RedniBroj,PoslovnaGodina,Datum,RedniBrojRacuna,JIB,Naziv,Adresa,NazivMjesto) as
select RedniBroj,PoslovnaGodina,Datum,RedniBrojRacuna,JIB,Naziv,Adresa,NazivMjesto from otpremnica natural join stavka_knjige_trgovine_na_veliko natural join partner natural join mjesto;

drop view if exists otpremnica_bezPartnera;
create view otpremnica_bezPartnera(RedniBroj,PoslovnaGodina,Datum,RedniBrojRacuna,JIB) as
select RedniBroj,PoslovnaGodina,Datum,RedniBrojRacuna,JIB from otpremnica natural join stavka_knjige_trgovine_na_veliko;

drop view if exists kalkulacija_bezPartnera;
create view kalkulacija_bezPartnera(RedniBroj,PoslovnaGodina,BrojFaktureDobavljaca,Datum,JIB) as 
select k.RedniBroj,PoslovnaGodina,BrojFaktureDobavljaca,Datum,JIB from kalkulacija k inner join stavka_knjige_trgovine_na_veliko s on k.RedniBroj=s.RedniBroj;

drop view if exists stavka_kalkulacija_view;
create view stavka_kalkulacija_view(RedniBroj,SifraRoba,Kolicina,NabavnaCijena,Rabat,NetoNabavnaCijena,VeleprodajnaCijena,RazlikaUCijeni,NabavnaVrijednost,VeleprodajnaVrijednost)as
select RedniBroj,SifraRoba,Kolicina,NabavnaCijena,Rabat,NabavnaCijena-NabavnaCijena*Rabat/100 as NetoNabavnaCijena,VeleprodajnaCijena, VeleprodajnaCijena-(NabavnaCijena-NabavnaCijena*Rabat) as RazlikaUCijeni, Kolicina*(NabavnaCijena-NabavnaCijena*Rabat/100) as NabavnaVrijednost,Kolicina*(VeleprodajnaCijena) as VeleprodajnaVrijednost from veleprodaja.stavka_kalkulacije;

drop view if exists stavka_kalkulacija_view_detaljno;
create view stavka_kalkulacija_view_detaljno(RedniBroj,SifraRoba,Naziv,SifraJediniceMjere,OpisJediniceMjere,Kolicina,NabavnaCijena,Rabat,NetoNabavnaCijena,VeleprodajnaCijena,RazlikaUCijeni,NabavnaVrijednost,VeleprodajnaVrijednost)as
select RedniBroj,sk.SifraRoba,Naziv,jm.SifraJediniceMjere,OpisJediniceMjere,Kolicina,NabavnaCijena,Rabat,NabavnaCijena-NabavnaCijena*Rabat/100 as NetoNabavnaCijena,VeleprodajnaCijena, VeleprodajnaCijena-(NabavnaCijena-NabavnaCijena*Rabat) as RazlikaUCijeni, Kolicina*(NabavnaCijena-NabavnaCijena*Rabat/100) as NabavnaVrijednost,Kolicina*(VeleprodajnaCijena) as VeleprodajnaVrijednost from veleprodaja.stavka_kalkulacije sk inner join veleprodaja.roba v on sk.SifraRoba=v.SifraRoba inner join veleprodaja.jedinica_mjere jm on v.SifraJediniceMjere=jm.SifraJediniceMjere;

drop procedure if exists iznosKalkulacije;
delimiter $$
create procedure iznosKalkulacije (in rb int, out veleprodajniIznos double,out nabavniIznos double, out razlikaUCijeni double)
begin 
set nabavniIznos=0.0;
set veleprodajniIznos=0.0;
select sum(VeleprodajnaVrijednost),sum(NabavnaVrijednost)  into veleprodajniIznos,nabavniIznos from stavka_kalkulacija_view where RedniBroj=rb;
set razlikaUCijeni=veleprodajniIznos-nabavniIznos;
end $$
delimiter ;

drop procedure if exists getCijenaIKolicina;

delimiter $$
create procedure getCijenaIKolicina(in sifra int,out prodajna double, out kol double)
begin
declare nabavljenaKolicina double;
declare prodataKolicina double;
set nabavljenaKolicina=0;
set prodataKolicina=0;
select VeleprodajnaCijena into prodajna from stavka_kalkulacije natural join kalkulacija natural join stavka_knjige_trgovine_na_veliko where SifraRoba=sifra order by Datum desc ,RedniBroj desc limit 1;
select sum(Kolicina) into nabavljenaKolicina  from stavka_kalkulacije where sifraRoba=sifra;
select sum(Kolicina) into prodataKolicina from stavka_otpremnice where sifraRoba=sifra;
if(isnull(prodataKolicina))then
set prodataKolicina=0;
end if;
if(isnull(nabavljenaKolicina)) then
set nabavljenaKolicina=0;
end if;
set kol=nabavljenaKolicina-prodataKolicina;

end $$
delimiter ;

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
