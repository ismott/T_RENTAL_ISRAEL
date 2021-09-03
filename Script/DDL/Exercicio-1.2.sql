Create Database LocadoraVeiculos;
GO

Use LocadoraVeiculos;
Go

Create Table Empresa(
EmpresaId Tinyint Primary Key Identity(1,1),
NomeEmpresa Varchar(30) Not Null  
);
Go

Create Table Cliente(
ClienteId Tinyint Primary Key Identity(1,1),
Nome Varchar(20) Not Null,
Sobrenome Varchar(20) Not Null,
CNH Char(5) Not Null,
);

Create Table Marca(
MarcaId Tinyint Primary Key Identity(1,1),
NomeMarca Varchar(20) Not Null  
);

Create Table Modelo(
ModeloId Smallint Primary Key Identity(1,1),
MarcaId Tinyint Foreign Key References Marca(MarcaId), 
NomeModelo Varchar(20) Not Null  
);

Create Table Veiculo(
VeiculoId Smallint Primary Key Identity(1,1),
ModeloId Smallint Foreign Key References Modelo(ModeloId),
EmpresaId Tinyint Foreign Key References Empresa(EmpresaId),
NomeModelo Varchar(20) Not Null,
Placa char(7) Not Null Unique
);

Create Table Aluguel(
AluguelID Int Primary Key Identity(1,1),
VeiculoId Smallint Foreign Key References Veiculo(VeiculoId),
ClienteId Tinyint Foreign Key References Cliente(ClienteId),
DataAluguel Varchar(10) Not Null,
DataDevolucao Varchar(10) Not Null,
);

Update Aluguel Set DataAluguel = 'a', DataDevolucao = 'a' WHERE AluguelId = 1