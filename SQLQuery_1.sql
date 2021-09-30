DROP TABLE Customer;
DROP TABLE Store;
DROP TABLE Item;
DROP TABLE Size;
DROP TABLE Orders;

CREATE TABLE Customer (
    Id INT PRIMARY KEY IDENTITY,
    Username VARCHAR(50),
    Password VARCHAR(50),
    Email VARCHAR(50)
);

CREATE TABLE Store (
    Id INT PRIMARY KEY IDENTITY,
    Address VARCHAR(100),
    City VARCHAR(50),
    State VARCHAR(50)
);

CREATE TABLE Item (
    Id INT PRIMARY KEY IDENTITY,
    Name VARCHAR(50),
    Price DECIMAL,
    StoreId INT FOREIGN KEY REFERENCES Store(Id)
);

CREATE TABLE Orders (
    Id INT PRIMARY KEY IDENTITY,
    CustomerId INT FOREIGN KEY REFERENCES Customer(Id) ON DELETE CASCADE NOT NULL,
    StoreId INT FOREIGN KEY REFERENCES Store(Id) ON DELETE CASCADE NOT NULL
);

CREATE TABLE Size (
    Id INT PRIMARY KEY IDENTITY,
    ClothingSize VARCHAR(3),
    SizeQuantity INT,
    ItemId INT FOREIGN KEY REFERENCES Item(Id) ON DELETE CASCADE NOT NULL
);

INSERT INTO Store (Address, City, State)
VALUES ('1234 W Bodega Ave', 'Denver', 'CO');
INSERT INTO Store (Address, City, State)
VALUES ('5678 S Belmont Rd', 'Los Angelos', 'CA');

INSERT INTO Item (Name, Price, StoreId)
VALUES ('Classic Warm Up Hoodie', 155.00, 1);
INSERT INTO Item (Name, Price, StoreId)
VALUES ('Classic Warm Up Pants', 125.00, 2);

INSERT INTO Orders (CustomerId, StoreId)
VALUES (155.00, 1, 1);

INSERT INTO Size (ClothingSize, SizeQuantity, ItemId)
VALUES ('S', 5, 1), ('M', 5, 1), ('X', 5, 1), ('XL', 5, 1);
INSERT INTO Size (ClothingSize, SizeQuantity, ItemId)
VALUES ('S', 5, 2), ('M', 5, 2), ('X', 5, 2), ('XL', 5, 2);

SELECT * FROM Customer;
SELECT * FROM Store;
SELECT * FROM Item;
SELECT * FROM Size;
SELECT * FROM Orders;

SELECT Orders.Id, Customer.Username, Customer.Email, Item.Name, Item.Price
FROM Orders
INNER JOIN Customer
ON Orders.CustomerId = Customer.Id
INNER JOIN Store
ON Orders.StoreId = Store.Id
INNER JOIN Item
ON Item.StoreId = Store.Id
WHERE Customer.id = 5;

Delete FROM Size where id = 9;


