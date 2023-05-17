create table PizzasList
(
    imageUrl    varchar(188)       not null,
    id          int IDENTITY (1,1) not null,
    description varchar(186)       not null,
    name        varchar(18)        not null,
    price       int                not null
);


Select * from PizzasList;