Select * From Empresa;
Select * From Aluguel;
Select * From Modelo;
Select * From Marca;
Select * From Veiculo;
Select * From Cliente;
Go

Select AluguelId, DataAluguel, DataDevolucao, Cliente.Nome, Veiculo.Placa PlacaCarro From Aluguel Inner Join Veiculo On Aluguel.VeiculoId = Veiculo.VeiculoId Inner Join Cliente On Aluguel.ClienteId = Cliente.ClienteId; 
Go

Select Modelo.NomeModelo, Placa, Empresa.NomeEmpresa, Marca.NomeMarca From Veiculo Right Join Modelo On Veiculo.ModeloId = Modelo.MarcaId Right Join Empresa On Veiculo.EmpresaId = Empresa.EmpresaId Right Join Marca On Modelo.MarcaId = Marca.MarcaId Where VeiculoId = 1 

Select Nome, Sobrenome, CNH From Cliente