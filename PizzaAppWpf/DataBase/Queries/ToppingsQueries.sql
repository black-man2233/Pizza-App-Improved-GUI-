Drop Table if exists Toppings;

create table Toppings
(
    ID    int IDENTITY (1,1),
    Name  varchar(20),
    Price int,
);


-- Insert Toppings
insert into Toppings (Name, Price)
values ('Pepperoni', 10),
       ('Mushrooms', 10),
       ('Onions', 10),
       ('Sausage', 10),
       ('Bacon', 10),
       ('Extra cheese', 10),
       ('Black olives', 10),
       ('Green peppers', 10),
       ('Pineapple', 10),
       ('Spinach', 10),
       ('Broccoli', 10),
       ('Chicken', 10),
       ('Ham', 10),
       ('Beef', 10),
       ('Salami', 10),
       ('Anchovies', 10);

Select * from Toppings;
