using System;
using System.Collections.Generic;
using MySqlConnector;

namespace ATIVIDADE_2.Models
{
    public class UsuarioRepository
    {
        private const string DadosConexao = "Database=DestinoCerto;Data Source=localhost; User Id=root";

        public void TestarConexao()
        {

            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            Console.WriteLine("Banco de dados funcionando corretamente");
            Conexao.Close();
        }


        public Usuario ValidarLogin(Usuario user)
        {


            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();


            string SqlConsultaLoginSenha = "select * from Usuario WHERE Login=@Login and Senha=@Senha";


            MySqlCommand Comando = new MySqlCommand(SqlConsultaLoginSenha, Conexao);


            Comando.Parameters.AddWithValue("@Login", user.Login);
            Comando.Parameters.AddWithValue("@Senha", user.Senha);


            MySqlDataReader Reader = Comando.ExecuteReader();


            Usuario userEncontrado = null;


            if (Reader.Read())
            {

                userEncontrado = new Usuario();
                userEncontrado.Id = Reader.GetInt32("Id");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    userEncontrado.Nome = Reader.GetString("Nome");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Login")))
                    userEncontrado.Login = Reader.GetString("Login");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Senha")))
                    userEncontrado.Senha = Reader.GetString("Senha");


                userEncontrado.DataNascimento = Reader.GetDateTime("DataNascimento");

            }

            //fechar a conexao
            Conexao.Close();

            //retornar a lista 
            return userEncontrado;

        }

        public void Inserir(Usuario user)
        {
            //abrir a conexao
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            //slq de inclusao
            String SqlInclusao = "Insert into Usuario (Nome,Login,Senha,DataNascimento) VALUES(@Nome,@Login,@Senha,@DataNascimento)";

            //prepara o comando (o que tem nele? sqlInclusao + Conexao - local do banco de dados)
            MySqlCommand Comando = new MySqlCommand(SqlInclusao, Conexao);

            //tratamento para o sql injection 

            Comando.Parameters.AddWithValue("@Nome", user.Nome);
            Comando.Parameters.AddWithValue("@Login", user.Login);
            Comando.Parameters.AddWithValue("@Senha", user.Senha);
            Comando.Parameters.AddWithValue("@DataNascimento", user.DataNascimento);

            //execucao no banco de dados 
            Comando.ExecuteNonQuery();
            //fechar a conexao

            Conexao.Close();

        }


        public void Atualizar(Usuario user)
        {
            //abrir a conexao
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            //slq de atualizacao
            String SqlAtualizacao = "update Usuario SET Nome=@Nome,Login=@Login,Senha=@Senha,DataNascimento=@DataNascimento WHERE Id=@Id";

            //prepara o comando (o que tem nele? sqlAtualizacao + Conexao - local do banco de dados)
            MySqlCommand Comando = new MySqlCommand(SqlAtualizacao, Conexao);

            //tratamento para o sql injection 
            Comando.Parameters.AddWithValue("@Id", user.Id);
            Comando.Parameters.AddWithValue("@Nome", user.Nome);
            Comando.Parameters.AddWithValue("@Login", user.Login);
            Comando.Parameters.AddWithValue("@Senha", user.Senha);
            Comando.Parameters.AddWithValue("@DataNascimento", user.DataNascimento);

            //execucao no banco de dados 
            Comando.ExecuteNonQuery();
            //fechar a conexao

            Conexao.Close();

        }

        public void Remover(Usuario user)
        {

            //abrir a conexao
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();


            //slq de exclusao 

            String SqlExclusao = "delete from Usuario WHERE Id=@Id";

            //prepara o comando (o que tem nele? sqlExclusao - local do banco de dados)
            MySqlCommand Comando = new MySqlCommand(SqlExclusao, Conexao);

            //tratamento para o sql injection 
            Comando.Parameters.AddWithValue("@Id", user.Id);

            //execucao no banco de dados 
            Comando.ExecuteNonQuery();

            //fechar a conexao
            Conexao.Close();

        }




        public List<Usuario> Listar()
        {


            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();


            string SqlConsulta = "select * from Usuario";


            MySqlCommand Comando = new MySqlCommand(SqlConsulta, Conexao);
            MySqlDataReader Reader = Comando.ExecuteReader();


            List<Usuario> lista = new List<Usuario>();


            while (Reader.Read())
            {

                Usuario user = new Usuario();

                user.Id = Reader.GetInt32("Id");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    user.Nome = Reader.GetString("Nome");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Login")))
                    user.Login = Reader.GetString("Login");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Senha")))
                    user.Senha = Reader.GetString("Senha");

                user.DataNascimento = Reader.GetDateTime("DataNascimento");


                lista.Add(user);

            }



            Conexao.Close();


            return lista;


        }


        public Usuario BuscarPorID(int Id)
        {

            //abrir a conexao
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            //sql de consulta 
            string SqlConsultaId = "select * from Usuario WHERE Id=@Id";

            //prepara o comando (SqlConsultaId + conexao local do banco de dados)
            MySqlCommand Comando = new MySqlCommand(SqlConsultaId, Conexao);

            //tratamento para o sql injection 
            Comando.Parameters.AddWithValue("@Id", Id);


            MySqlDataReader Reader = Comando.ExecuteReader(); //executar o comando

            Usuario userEncontrado = new Usuario();


            if (Reader.Read())
            {

                userEncontrado.Id = Reader.GetInt32("Id");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    userEncontrado.Nome = Reader.GetString("Nome");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Login")))
                    userEncontrado.Login = Reader.GetString("Login");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Senha")))
                    userEncontrado.Senha = Reader.GetString("Senha");


                userEncontrado.DataNascimento = Reader.GetDateTime("DataNascimento");

            }

            //fechar a conexao
            Conexao.Close();

            //retornar a lista 
            return userEncontrado;





        }




    }
}

