
drop view if exists roba_sa_jedinicom_mjere;
create view roba_sa_jedinicom_mjere(SifraRoba,Naziv,SifraJediniceMjere,OpisJediniceMjere) as
select SifraRoba,Naziv,r.SifraJediniceMjere,OpisJediniceMjere from roba r inner join jedinica_mjere j on r.SifraJediniceMjere=j.SifraJediniceMjere;

-- KALKULACIJE 

drop view if exists kalkulacija_osnovno;
create view kalkulacija_osnovno(RedniBroj,PoslovnaGodina,BrojFaktureDobavljaca,Datum,JIB,Naziv,Adresa,PostanskiBroj,NazivMjesto) as
SELECT k.RedniBroj,PoslovnaGodina,BrojFaktureDobavljaca,Datum,p.JIB,p.Naziv,p.Adresa,p.PostanskiBroj,m.NazivMjesto FROM veleprodaja.kalkulacija k inner join stavka_knjige_trgovine_na_veliko s on s.RedniBroj=k.RedniBroj inner join partner p on p.jib=s.jib inner join mjesto m on m.PostanskiBroj=p.PostanskiBroj;


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


-- OTPREMNICE

drop view if exists otpremnica_osnovno;
create view otpremnica_osnovno(RedniBroj,PoslovnaGodina,Datum,RedniBrojRacuna,JIB,Naziv,Adresa,PostanskiBroj,NazivMjesto) as
select RedniBroj,PoslovnaGodina,Datum,RedniBrojRacuna,JIB,Naziv,Adresa,PostanskiBroj,NazivMjesto 
from otpremnica natural join stavka_knjige_trgovine_na_veliko natural join partner natural join mjesto;

drop view if exists stavka_otpremnica_view;
create view stavka_otpremnica_view(RedniBroj,SifraRoba,Kolicina,VeleprodajnaCijena,Rabat,CijenaSaRabatom,VeleprodajniIznos,IznosSaRabatom)as
select RedniBroj,SifraRoba,Kolicina,VeleprodajnaCijena,Rabat,VeleprodajnaCijena-Rabat*VeleprodajnaCijena/100 as CijenaSaRabatom,
Kolicina*VeleprodajnaCijena as VeleprodajniIznos,
Kolicina*(VeleprodajnaCijena-Rabat*VeleprodajnaCijena/100)as IznosSaRabatom from stavka_otpremnice;
 
drop view if exists stavka_otpremnica_view_detaljno;
create view stavka_otpremnica_view_detaljno(RedniBroj,SifraRoba,Naziv,SifraJediniceMjere,OpisJediniceMjere,Kolicina,VeleprodajnaCijena,Rabat,CijenaSaRabatom,VeleprodajniIznos,IznosSaRabatom)as
SELECT RedniBroj,SifraRoba,Naziv,SifraJediniceMjere,OpisJediniceMjere,Kolicina,VeleprodajnaCijena,Rabat,CijenaSaRabatom,VeleprodajniIznos,IznosSaRabatom FROM veleprodaja.stavka_otpremnica_view natural join roba natural join jedinica_mjere;



drop procedure if exists iznosOtpremnice;
delimiter $$
create procedure iznosOtpremnice (in rb int, out velIznos double,out izSaRabatom double,out iznosRabata double)
begin 
set velIznos=0.0;
set izSaRabatom=0.0;
select sum(VeleprodajniIznos),sum(IznosSaRabatom)  from stavka_otpremnica_view where RedniBroj=rb;
select sum(VeleprodajniIznos),sum(IznosSaRabatom)  into velIznos,izSaRabatom from stavka_otpremnica_view where RedniBroj=rb;
set iznosRabata=velIznos-izSaRabatom;
end $$
delimiter ;

drop table if exists stavka_kalkulacija_backup;
create table stavka_kalkulacija_backup(
id_backup integer not null auto_increment ,
	RedniBroj             INTEGER NOT NULL,
	SifraRoba             INTEGER NOT NULL,
	Kolicina              INTEGER NOT NULL,
	NabavnaCijena         FLOAT NOT NULL,
	Rabat                 FLOAT NOT NULL,
	VeleprodajnaCijena    FLOAT NOT NULL,
    vrijeme datetime,
	 PRIMARY KEY (id_backup)
     );

drop table if exists STAVKA_OTPREMNICE_BACKUP;
CREATE TABLE STAVKA_OTPREMNICE_BACKUP
(
id_backup integer not null auto_increment,
	SifraRoba             INTEGER NOT NULL,
	RedniBroj             INTEGER NOT NULL,
	Kolicina              FLOAT NOT NULL,
	VeleprodajnaCijena    FLOAT NOT NULL,
	Rabat                 FLOAT NULL,
    Vrijeme datetime null,
	 PRIMARY KEY (id_backup)
)
;

drop trigger if exists stavka_kalkulacije_bck_update;
create trigger stavka_kalkulacije_bck_update before update on stavka_kalkulacije
for each row
insert into stavka_kalkulacija_backup(RedniBroj,SifraRoba,Kolicina,NabavnaCijena,Rabat,VeleprodajnaCijena,Vrijeme) values(old.RedniBroj,old.SifraRoba,old.Kolicina,old.NabavnaCijena,old.Rabat,old.VeleprodajnaCijena,sysdate());

drop trigger if exists stavka_kalkulacije_bck_delete;
create trigger stavka_kalkulacije_bck_delete before delete on stavka_kalkulacije
for each row
insert into stavka_kalkulacija_backup(RedniBroj,SifraRoba,Kolicina,NabavnaCijena,Rabat,VeleprodajnaCijena,Vrijeme) values(old.RedniBroj,old.SifraRoba,old.Kolicina,old.NabavnaCijena,old.Rabat,old.VeleprodajnaCijena,sysdate());

drop trigger if exists stavka_otpremnice_bck_update;
create trigger stavka_otpremnice_bck_update before update on stavka_otpremnice
for each row
insert into stavka_otpremnice_backup(RedniBroj,SifraRoba,Kolicina,VeleprodajnaCijena,Rabat,Vrijeme) values (old.RedniBroj,old.SifraRoba,old.Kolicina,old.VeleprodajnaCijena,old.Rabat,sysdate());

drop trigger if exists stavka_otpremnice_bck_delete;
create trigger stavka_otpremnice_bck_delete before delete on stavka_otpremnice
for each row
insert into stavka_otpremnice_backup(RedniBroj,SifraRoba,Kolicina,VeleprodajnaCijena,Rabat,Vrijeme) values (old.RedniBroj,old.SifraRoba,old.Kolicina,old.VeleprodajnaCijena,old.Rabat,sysdate());

drop trigger if exists stavka_knjige_delete;
delimiter $$
create trigger stavka_knjige_delete after delete on stavka_knjige_trgovine_na_veliko
for each row
begin
delete from kalkulacija where RedniBroj=old.RedniBroj;
delete from otpremnica where RedniBroj=old.RedniBroj;
delete from nivelacija where RedniBroj=old.RedniBroj;
end $$
delimiter ;


drop procedure if exists inserting_otpremnica;
delimiter $$ 
create procedure inserting_otpremnica(in godina integer, in jibPartnera integer, in datumOtpremnice date,out RedniBroj integer)
begin
insert into stavka_knjige_trgovine_na_veliko (`PoslovnaGodina`,`JIB`,`Datum`) values (godina,jibPartnera,datumOtpremnice);
set RedniBroj=LAST_INSERT_ID();
insert into otpremnica (`RedniBroj`) values(RedniBroj);
end$$
delimiter ;

drop procedure if exists inserting_kalkulacija;
delimiter $$ 
create procedure inserting_kalkulacija(in godina integer, in jibPartnera integer, in datumOtpremnice date,in brojFak varchar(50),out RedniBroj integer)
begin
insert into stavka_knjige_trgovine_na_veliko (`PoslovnaGodina`,`JIB`,`Datum`) values (godina,jibPartnera,datumOtpremnice);
set RedniBroj=LAST_INSERT_ID();
insert into kalkulacija (`RedniBroj`,`BrojFaktureDobavljaca`) values(RedniBroj,brojFak);
end$$
delimiter ;


drop trigger if exists inserting_stavka_knjige;
delimiter $$
create trigger inserting_stavka_knjige before insert on stavka_knjige_trgovine_na_veliko
for each row
begin
declare s int;
set s=(select count(PoslovnaGodina) from knjiga_trgovine_na_veliko);
if (s<1) then
insert into knjiga_trgovine_na_veliko (PoslovnaGodina) values (new.PoslovnaGodina);
end if;
end$$
delimiter ;







