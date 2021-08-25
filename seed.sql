-- SQLite
-- INSERT INTO Users (Name, Username, Password, Type, Status) VALUES ('Admin', 'admin', 'qwe12345', 1, 1);
-- INSERT INTO Categories (Name, Description, Status) VALUES ('Lanches', '', 1), ('Refrigerantes', '', 1), ('Diversos', '', 1);

INSERT INTO Products (Ref, Name, Description, Image, CategoryId, Quantity, CostPrice, Price, Status)
VALUES ('xburguer', 'X-Burguer', '', '', 1, 10, 8, 13, 1),
('xsalada', 'X-Salada', '', '', 1, 10, 10, 15, 1),
('coca', 'Coca-Cola', '', '',  2, 10, 7, 11, 1);