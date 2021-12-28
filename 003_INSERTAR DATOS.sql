GO
USE DB_CARRITO


go


insert into USUARIO(Nombres,Apellidos,Correo,Contrasena,EsAdministrador) values ('test','user','admin@udla.com','admin123',1)

GO
insert into CATEGORIA(Descripcion) values
('Hamburguesa'),
('Bebidas'),
('Pizza'),
('Sushi'),
('Adicionales')

GO

insert into MARCA(Descripcion) values
('MCDonalds'),
('Kobe'),
('Hornero'),
('CocaCola'),
('Nacional')

GO



insert into PRODUCTO(Nombre,Descripcion,IdMarca,IdCategoria,Precio,Stock,RutaImagen) values('Cuarto de libra','
Pan de ajonjoli
pickles
Cuarto de libra de carne
',1,1,'7','1000','~/Imagenes/Productos/1.png')



insert into PRODUCTO(Nombre,Descripcion,IdMarca,IdCategoria,Precio,Stock,RutaImagen) values('Mcnifica','
Pan de ajonjoli
Tomate, lechuga
carne
salsa mcdonalds',1,1,'6','1000','~/Imagenes/Productos/2.png')


insert into PRODUCTO(Nombre,Descripcion,IdMarca,IdCategoria,Precio,Stock,RutaImagen) values('Sprite','
bebida sprite 200 ml
Cocacola
',4,2,'2','1000','~/Imagenes/Productos/3.jpg')

insert into PRODUCTO(Nombre,Descripcion,IdMarca,IdCategoria,Precio,Stock,RutaImagen) values('Pizza de jamon  mediana','Pizza cuadrada con jamon tamanio mediana',3,3,'8','1000','~/Imagenes/Productos/4.jpg')
insert into PRODUCTO(Nombre,Descripcion,IdMarca,IdCategoria,Precio,Stock,RutaImagen) values('Rollo California','',2,4,'12','1000','~/Imagenes/Productos/5.jpg')
insert into PRODUCTO(Nombre,Descripcion,IdMarca,IdCategoria,Precio,Stock,RutaImagen) values('Hornado','',5,5,'3','1000','~/Imagenes/Productos/6.jpg')



go
