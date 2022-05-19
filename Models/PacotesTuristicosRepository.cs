using System;
using System.Collections.Generic;
using MySqlConnector;

namespace ATIVIDADE_2.Models
{
    public class PacotesTuristicosRepository
    {
        private const string DadosConexao = "Database=DestinoCerto;Data Source=localhost;User Id=root;";

        public void TestarConexao()
        {

            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            Console.WriteLine("Banco de dados funcionando corretamente");
            Conexao.Close();
        }


        //TODO O CRUD
        //Inserir 
        //Atualizar


        public void Inserir(PacotesTuristicos pac)
        {
            //abrir a conexao
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            //slq de inclusao
            String SqlInclusao = "insert into PacotesTuristicos (Nome,Origem,Destino,Atrativos,Saida,Retorno)" + "VALUES(@Nome,@Origem,@Destino,@Atrativos,@Saida,@Retorno)";
            //String SqlInclusao = "insert into PacotesTuristicos (Nome,Origem,Destino,Atrativos,Saida,Retorno,Usuario)             VALUES(@Nome,@Origem,@Destino,@Atrativos,@Saida,@Retorno,@Usuario)";

            //prepara o comando (o que tem nele? sqlInclusao + Conexao - local do banco de dados)
            MySqlCommand Comando = new MySqlCommand(SqlInclusao, Conexao);

            //tratamento para o sql injection 

            Comando.Parameters.AddWithValue("@Nome", pac.Nome);
            Comando.Parameters.AddWithValue("@Origem", pac.Origem);
            Comando.Parameters.AddWithValue("@Destino", pac.Destino);
            Comando.Parameters.AddWithValue("@Atrativos", pac.Atrativos);
            Comando.Parameters.AddWithValue("@Saida", pac.Saida);
            Comando.Parameters.AddWithValue("@Retorno", pac.Retorno);
            //Comando.Parameters.AddWithValue("@usuario", pac.Usuario);
            Comando.Parameters.AddWithValue("@usuario", pac.Usuario);



            //execucao no banco de dados 
            Comando.ExecuteNonQuery();
            //fechar a conexao

            Conexao.Close();

        }


        public void Atualizar(PacotesTuristicos pac)
        {
            //abrir a conexao
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            //slq de atualizacao
            //String SqlAtualizacao = "update PacotesTuristicos SET Nome=@Nome, Origem=@Origem, Destino=@Destino, Atrativo=@Atrativo, Saida=@Saida, Retorno=@Retorno, Usuario=@Usuario WHERE Id=@Id";
            String SqlAtualizacao = "update PacotesTuristicos SET Nome=@Nome, Origem=@Origem, Destino=@Destino,Atrativos=@Atrativos, Saida=@Saida, Retorno=@Retorno WHERE Id=@Id";

            //prepara o comando (o que tem nele? sqlAtualizacao + Conexao - local do banco de dados)
            MySqlCommand Comando = new MySqlCommand(SqlAtualizacao, Conexao);

            //tratamento para o sql injection 
            Comando.Parameters.AddWithValue("@Id", pac.Id);
            Comando.Parameters.AddWithValue("@Nome", pac.Nome);
            Comando.Parameters.AddWithValue("@Origem", pac.Origem);
            Comando.Parameters.AddWithValue("@Destino", pac.Destino);
            Comando.Parameters.AddWithValue("@Atrativos", pac.Atrativos);
            Comando.Parameters.AddWithValue("@Saida", pac.Saida);
            Comando.Parameters.AddWithValue("@Retorno", pac.Retorno);
            //Comando.Parameters.AddWithValue("@Usuario", pac.Usuario);



            //execucao no banco de dados 
            Comando.ExecuteNonQuery();
            //fechar a conexao

            Conexao.Close();

        }



        public void Remover(PacotesTuristicos pac)
        {

            //abrir a conexao
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();


            //slq de exclusao 

            String SqlExclusao = "delete from PacotesTuristicos WHERE Id=@Id";

            //prepara o comando (o que tem nele? sqlExclusao - local do banco de dados)
            MySqlCommand Comando = new MySqlCommand(SqlExclusao, Conexao);

            //tratamento para o sql injection 
            Comando.Parameters.AddWithValue("@Id", pac.Id);

            //execucao no banco de dados 
            Comando.ExecuteNonQuery();

            //fechar a conexao
            Conexao.Close();

        }




        public List<PacotesTuristicos> Listar()
        {

            //abrir a conexao
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            //sql de consulta 
            string SqlConsulta = "select * from PacotesTuristicos";

            //prepara o comando (o que tem nele? sqlconsulta + conexao local do banco de dados)
            MySqlCommand Comando = new MySqlCommand(SqlConsulta, Conexao);
            MySqlDataReader Reader = Comando.ExecuteReader(); //executar o comando

            //criar a Lista de Usuarios do banco de dados
            List<PacotesTuristicos> lista = new List<PacotesTuristicos>();

            //percorrer os registros que foram executados em 'Reader'
            while (Reader.Read())
            {
                //alimer o objeto 'user' com informaçoes do Reader
                PacotesTuristicos pac = new PacotesTuristicos();

                pac.Id = Reader.GetInt32("Id");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    pac.Nome = Reader.GetString("Nome");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Origem")))
                    pac.Origem = Reader.GetString("Origem");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Destino")))
                    pac.Destino = Reader.GetString("Destino");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Atrativos")))
                    pac.Atrativos = Reader.GetString("Atrativos");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Saida")))
                    pac.Saida = Reader.GetDateTime("Saida");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Retorno")))
                    pac.Retorno = Reader.GetDateTime("Retorno");


                // pac.Usuario = Reader.GetInt32("Usuario");
                if (!Reader.IsDBNull(Reader.GetOrdinal("Usuario")))
                    pac.Usuario = Reader.GetInt32("Usuario");

                //acicionar na lista o objeto 'user' item a item de acordo com o percurso
                lista.Add(pac);

            }


            //fechar a conexao
            Conexao.Close();

            //retornar a lista 
            return lista;


        }


        public PacotesTuristicos BuscarPorID(int Id)
        {

            //abrir a conexao
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            //sql de consulta 
            string SqlConsultaId = "select * from PacotesTuristicos WHERE Id=@Id";

            //prepara o comando (SqlConsultaId + conexao local do banco de dados)
            MySqlCommand Comando = new MySqlCommand(SqlConsultaId, Conexao);

            //tratamento para o sql injection 
            Comando.Parameters.AddWithValue("@Id", Id);


            MySqlDataReader Reader = Comando.ExecuteReader(); //executar o comando

            PacotesTuristicos pacEncontrado = new PacotesTuristicos();


            if (Reader.Read())
            {
                if (!Reader.IsDBNull(Reader.GetOrdinal("Id")))
                    pacEncontrado.Id = Reader.GetInt32("Id");


                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    pacEncontrado.Nome = Reader.GetString("Nome");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Origem")))
                    pacEncontrado.Origem = Reader.GetString("Origem");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Destino")))
                    pacEncontrado.Destino = Reader.GetString("Destino");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Atrativos")))
                    pacEncontrado.Atrativos = Reader.GetString("Atrativos");


                pacEncontrado.Saida = Reader.GetDateTime("Saida");


                pacEncontrado.Retorno = Reader.GetDateTime("Retorno");

                // pacEncontrado.Usuario = Reader.GetInt32("Usuario");

            }

            //fechar a conexao
            Conexao.Close();

            //retornar a lista 
            return pacEncontrado;





        }
    }
}