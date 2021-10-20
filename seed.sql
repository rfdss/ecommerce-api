
INSERT INTO Users (Name, Username, Password, Type, Status)
VALUES
('Admin', 'admin', 'qwe12345', 1, 1),
('Gerente 1', 'gerente1', 'qwe123', 1, 1),
('Operador 1', 'operador1', 'qwe123', 1, 1);

INSERT INTO Categories (Name, Description, Status)
VALUES
('Lanches', '', 1),
('Bebidas', '', 1),
('Doces', '', 1),
('Diversos', '', 1);

INSERT INTO Products (Ref, Name, Description, Image, CategoryId, Quantity, CostPrice, Price, Status)
VALUES
('xburguer', 'X-Burguer Normal', '', '', 1, 10, 8, 13, 1),
('xsalada', 'X-Salada Normal', '', '', 1, 10, 10, 15, 1),
('coca2l', 'Coca-Cola 2L', '', '',  2, 10, 7, 11, 1),
('sucolaranja1', 'Suco de laranja Natural One 300ml', '', '',  2, 10, 7, 11, 1),
('skol350', 'Skol Lata 350ml', '', '',  2, 10, 7, 11, 1),
('bombomnutella', 'Bombom Recheado Nutella e Ninho', '', '',  3, 10, 7, 11, 1);