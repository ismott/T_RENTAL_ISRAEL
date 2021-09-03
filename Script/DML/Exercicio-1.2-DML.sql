Use LocadoraVeiculos;
Go

Insert Into Empresa (NomeEmpresa) Values ('veiculo shop');
Go

Insert Into Marca (NomeMarca) Values ('VW'), ('Fiat');
Go

Insert Into Cliente (Nome, Sobrenome, CNH) Values ('Firmino', 'Silva', '12345'), ('Lucas', 'loico', '15614');
Go

Insert Into Modelo (MarcaId, NomeModelo) Values (2, 'Uno'), (1, 'Nivus');
Go

Insert Into Veiculo (EmpresaId, ModeloId, Placa, NomeModelo) Values (1, 1, '959', 'Uno'), (1, 2, '988', 'Nivus');
Go

Insert Into Aluguel (VeiculoId, ClienteId, DataAluguel, DataDevolucao) Values (2, 2, '21/12/2021', '26/12/2021'), (3, 1, '12/02/2021', '21/02/2021');
Go

