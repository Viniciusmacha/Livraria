using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;//Imports para conexão com o banco de dados
using MySql.Data.MySqlClient;//Imports para realizar comandos no banco
namespace BancoDeDadosTI13N
{
    class Livros


    {
        MySqlConnection conexao;
        public string[] codigo;
        public string[] titulo;
        public string[] ano;
        public string[] editora;
        public string dados;
        public string resultado;
        public int i;

        public DAO(string BancoDeDadosTI13N)
        {
            conexao = new MySqlConnection("server=localhost;DataBase=" + BancoDeDadosTI13N + ";Uid=root;Password=;");
            try
            {
                conexao.Open();//Solicitando a entrada ao banco de dados
                

            }
            catch (Exception e)
            {
                Console.WriteLine("Algo deu errado!\n\n" + e);
                conexao.Close();
            }

        }

        public void Inserir(string codigo, string titulo, string ano, string editora)
        {
            try
            {
                dados = "('" + codigo + "','" + titulo + "','" + ano + "','" + editora + "')";
                resultado = "Insert into Cliente(codigo, titulo, ano, editora) values" + dados;
                //Executar o comando resultado no banco de dados
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine(resultado + " Linha(s) Afetada(s)!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Algo deu errado!\n\n" + e);
            }


        }
        public void PreencherVetor()
        {
            string query = "select * from cliente";//Coletando o dado do BD

            //Instanciando os vetores
            codigo = new string[100];
            titulo = new string[100];
            ano = new string[100];
            editora = new string[100];

            //Dar valores iniciais para ele
            for (i = 0; i < 100; i++) ;
            {
                codigo[i] = "";
                titulo[i] = "";
                ano[i] = "";
                editora[i] = "";
                
            }
            MySqlCommand coletar = new MySqlCommand(query, conexao);
            //Usar o comando lendo os dados do banco
            MySqlDataReader leitura = coletar.ExecuteReader();
            i = 0;
            while (leitura.Read())
            {

            }//paramos aq



        }























    }// fim classe
} //fim do projeto

