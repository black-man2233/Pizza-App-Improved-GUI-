--Capacities
CREATE table Capacities
(
    ID    int IDENTITY (1,1),
    Name  varchar(30) not null,
    Price int         not null,
);

insert into Capacities (Name, Price)
values ('Small', 20),
       ('Medium', 30),
       ('Large', 50)

-- Drinks
create table Drinks
(
    imageUrl    varchar(200) not null,
    Name        varchar(11) not null,
    description varchar(90) not null
);

insert into Drinks (imageUrl, Name, description)
values ('https://w7.pngwing.com/pngs/574/913/png-transparent-coca-cola-coca-cola-bottle-glass-bottles.png', 'Coke',
        'Coke is a cola drink'),
       ('https://www.pngmart.com/files/22/Fanta-PNG-Isolated-Photo.png', 'Fanta', 'Fanta is a orange drink'),
       ('https://www.pngmart.com/files/22/Sprite-PNG-HD.png', 'Sprite', 'Sprite is a lemon drink'),
       ('https://png.pngtree.com/png-vector/20220701/ourmid/pngtree-mineral-water-bottle-vector-illstration-png-image_5626453.png', 'Water', 'Water is a water drink');

-- -- Extras
-- create table Extras
-- (
--     id    int IDENTITY (1,1),
--     name  varchar(8) not null,
--     price int,
-- );
-- 

