use Obligatorio_P3;
select * from Usuarios
select * from Lineas
select * from Pedidos
select * from Clientes
select * from Articulos

insert into Usuarios(email, nombre, apellido, contraseña, tipo) values ('admin@admin.com', 'Sys', 'Admin','Passw0rd!','Administrador');
insert into Usuarios(email, nombre, apellido, contraseña, tipo) values ('rplanta@lz.com', 'Roberto', 'Planta','Passw0rd!','Estandar');

insert into Clientes(razonSocial, rut, Direccion_Calle_Valor, Direccion_NumeroPuerta_Valor, Direccion_Ciudad_Valor, DistanciaHastaDeposito) values ('PF', '123456789012','Ciudadela','1182', 'Montevideo', 98);
insert into Clientes(razonSocial, rut, Direccion_Calle_Valor, Direccion_NumeroPuerta_Valor, Direccion_Ciudad_Valor, DistanciaHastaDeposito) values ('LZ', '987654321098', 'Reconquista', '590', 'Montevideo', 101);
insert into Clientes(razonSocial, rut, Direccion_Calle_Valor, Direccion_NumeroPuerta_Valor, Direccion_Ciudad_Valor, DistanciaHastaDeposito) values ('TWS', '111222333444', 'Durazno', '902', 'Montevideo', 96);

insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Calculadora Casio', 'Calculadora de bolsillo Casio', '1234567890123', 300, 10);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Resma A4', '500 hojas para imprimir en formato A4', '1234567890124', 250, 50);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Auriculares con Micrófono', 'Bluetooth o conexión USB, cable desmontable', '1234567890125', 3200, 20);
insert into Articulos(Nombre, Descripcion, CodigoProveedor, Precio, Stock) values ('Silla De Escritorio', 'Soporte lumbar, altura ajustable y base giratoria n ruedas', '1234567890126', 3200, 20);

insert into Parametros(Nombre, Valor) values ('IVA',0.18);

select * from  __EFMigrationsHistory
DELETE FROM __EFMigrationsHistory WHERE MigrationId='20240417232848_init'
DELETE FROM Usuarios