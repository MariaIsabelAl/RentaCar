Create database RentaDb

Drop table Alquileres

create table Alquileres(
     IdAlquilar Int Primary key identity,
     Matricula varchar(15),
     FechaEntrada date, 
     Duracion decimal,
     NombreCliente varchar(50),
     Cedula varchar(30),
     Telefono varchar(30),
     PrecioDiario decimal,
     Total decimal,
     Observacion varchar(100),
)


create table Proveedores(
     IdProveedor int Primary key identity, 
     Proveëdor varchar(50),
     Direccion varchar(50),
     Ciudad varchar(50),
     Telefono varchar(15),
     Email varchar(80)
)

create table Vehiculos(
      IdVehiculo int Primary key identity,
      Matricula varchar(10),
      Marca varchar(50),
      Modelo varchar(50),
      FechaCompra date,
      PrecioDiario decimal,
      IdProveedor int
)
