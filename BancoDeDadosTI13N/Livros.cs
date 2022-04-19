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
        public int [] codigo;
        public string[] titulo;
        public string[] ano;
        public string[] editora;
        public string dados;
        public string resultado;
        public int[] quantidade;
        public string msg;
        public int contador = 0;
        public int i;


        public Livros(string BancoDeDadosTI13N)
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

        public void Inserir(string codigo, string titulo, string ano, string editora, int quantidade)
        {
            try
            {
                dados = "('" + codigo + "','" + titulo + "','" + ano + "','" + editora + "'" + quantidade + "')";
                resultado = "Insert into Cliente(codigo, titulo, ano, editora, quantidade) values" + dados;
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
            string query = "select * from livros";//Coletando o dado do BD

            //Instanciando os vetores
            codigo = new int[100];
            titulo = new string[100];
            ano = new string[100];
            editora = new string[100];
            quantidade = new int[100];

            //Dar valores iniciais para ele
            for (i = 0; i < 100; i++)
            {
                codigo[i] = 0;
                titulo[i] = "";
                ano[i] = "";
                editora[i] = "";
                quantidade[i] = 0;



            }
            MySqlCommand coletar = new MySqlCommand(query, conexao);
            //Usar o comando lendo os dados do banco
            MySqlDataReader leitura = coletar.ExecuteReader();
            i = 0;
            contador = 0;
            while (leitura.Read())
            {
                codigo[i] = Convert.ToInt32(leitura["codigo"]);
                titulo[i] = leitura["titulo"] + "";
                ano[i] = leitura["ano"] + "";
                editora[i] = leitura["editora"] + "";
                quantidade[i] = Convert.ToInt32(leitura["quantidade"]);
                i++;
                contador++; 
            }
            leitura.Close();
        }
        public string ConsultarTudo()
        {

            PreencherVetor();
            msg = "";
            for (int i = 0; i < contador; i++)
            {
                msg += "\n\nCodigo: " + codigo[i]
                    + ", Titulo: " + titulo[i]
                    + ", Ano: " + ano[i]
                    + ", Editora: " + editora[i]
                    + ", Quantidade: " + quantidade[i];
            }
            return msg;
        }
        
      
        
        public string Consultartitulo(int cod)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (cod == codigo[i])
                {
                    return titulo[i];
                }
            }
            return "Titulo não encontrado!";
        }

        public string ConsultarAno(int cod)

        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (cod == codigo[i])
                {
                    return ano[i];
                }
            }
            return "Ano não encontrado!";
        }
        public string ConsultarEditora(int cod)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (cod == codigo[i])
                {
                    return editora[i];
                }
            }
            return "Editora não encontrado!";
        }
        public int ConsultarQuantidade(int cod)
        {
            PreencherVetor();
            for (int i = 23; i < contador; i++)
            {
                if (cod == codigo[i])
                {
                    return quantidade[i];
                }
            }
            return 23;
        }






















    }// fim classe
} //fim do projeto

