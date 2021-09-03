using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositores
{
    public class VeiculoRepository : IVeiculoRepository
    {

        private string StringConexao = "data source=HALLISONSIARA\\SQLEXPRESS; initial Catalog=T_Rental_Israel; user Id=sa; pwd=senai@132";
        public void AtualizarPorUrl(int IdVeiculo, VeiculoDomain VeiculoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryUpdate = "Update Veiculo Set Placa = @VeiculoPlaca WHERE VeiculoId = @idVeicoulo";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(QueryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@VeiculoPlaca", VeiculoAtualizado.Placa);
                    cmd.Parameters.AddWithValue("@idVeicoulo", IdVeiculo);

  

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public VeiculoDomain BuscaPorId(int IdVeiculo)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryBusca = "Select VeiculoId, Modelo.NomeModelo, Marca.NomeMarca, Empresa.NomeEmpresa, Placa From Veiculo Right Join Modelo On Veiculo.ModeloId = Modelo.MarcaId Right Join Empresa On Veiculo.EmpresaId = Empresa.EmpresaId Right Join Marca On Modelo.MarcaId = Marca.MarcaId  Where VeiculoId = @IdVeiculo";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(QueryBusca, con))
                {
                    cmd.Parameters.AddWithValue("@IdVeiculo", IdVeiculo);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        VeiculoDomain VeiculoBuscado = new VeiculoDomain()
                        {
                            VeiculoId = Convert.ToInt32(rdr[0]),
                            Modelo = new ModeloDomain()
                            {
                                NomeModelo = rdr[1].ToString(),
                                Marca = new MarcaDomain()
                                {
                                    NomeMarca = rdr[2].ToString()
                                }
                            },
                            Empresa = new EmpresaDomain()
                            {
                                NomeEmpresa = rdr[3].ToString()
                            },
                            Placa = rdr[4].ToString()
                        };

                        return VeiculoBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(VeiculoDomain NovoVeiculo)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryInsert = "Insert Into Veiculo (ModeloId, EmpresaId, Placa) Values (@ModeloId, @EmpresaId, @Placa)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(QueryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@ModeloId", NovoVeiculo.ModeloId);
                    cmd.Parameters.AddWithValue("@EmpresaId", NovoVeiculo.EmpresaId);
                    cmd.Parameters.AddWithValue("@Placa", NovoVeiculo.Placa);

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void Deletar(int IdVeiculo)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryInsert = "Delete From Veiculo Where VeiculoId = @IdVeiculo";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(QueryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@IdVeiculo", IdVeiculo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<VeiculoDomain> ListarTodos()
        {
            List<VeiculoDomain> ListarVeiculo = new List<VeiculoDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryListar = "Select VeiculoId, Modelo.NomeModelo,  Marca.NomeMarca, Empresa.NomeEmpresa, Placa From Veiculo Right Join Modelo On Veiculo.ModeloId = Modelo.MarcaId Right Join Empresa On Veiculo.EmpresaId = Empresa.EmpresaId Right Join Marca On Modelo.MarcaId = Marca.MarcaId";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(QueryListar, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        VeiculoDomain Veiculo = new VeiculoDomain()
                        {

                            VeiculoId = Convert.ToInt32(rdr[0]),
                            Modelo = new ModeloDomain()
                            {
                                NomeModelo = rdr[1].ToString(),
                                Marca = new MarcaDomain()
                                {
                                    NomeMarca = rdr[2].ToString(),
                                }
                            },
                            Empresa = new EmpresaDomain()
                            {
                                NomeEmpresa = rdr[3].ToString()
                            },
                            Placa = rdr[4].ToString()

                        };
                        ListarVeiculo.Add(Veiculo);
                    }
                }
            }
            return ListarVeiculo;
        }
    }
}
