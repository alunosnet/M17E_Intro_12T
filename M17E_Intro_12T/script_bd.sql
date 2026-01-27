-- tabela utilizadores
create table utilizadores(
	id int identity primary key,
	email varchar(100) not null unique 
		check (email like '%@%.%'),
	nome varchar(100),
	password varchar(
)