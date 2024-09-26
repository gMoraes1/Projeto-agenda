create database agenda;
use agenda;

create table tbcontato(
codcontato int not null primary key auto_increment,
nome varchar (100),
telefone char(14),
celular char(25),
email varchar(100));
 
insert into tbcontato(nome, telefone, celular, email) values('Samara Ferreira','(11)5555-4444', '(11)9777-8888','Samara.ferreira27@gmail.com');


create table tblogin(
login varchar(30)not null primary key,
senha varchar(30)not null
);

insert into tblogin(login,senha)values('adm','123');

select*from tbcontato
select*from tblogin