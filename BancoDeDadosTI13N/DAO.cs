using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;//Imports para conexão com o banco de dados
using MySql.Data.MySqlClient;//Imports para realizar comandos no banco

namespace BancoDeDadosTI13N
{
    class DAO
    {
        MySqlConnection conexao;
        public string livros;
        public string cliente;
        public string estoque;
        public string formaDePagamento;

        //Declarando os vetores:

        public long[] cpf;
        public string[] nome;
        public string[] endereco;
        public string[] telefone;
        public string[] dataDeNascimento;
        public string[] login;
        public string[] senha;
        public string dados;
        public string resultado;
        public int i;
        public string msg;
        public int contador = 0;
        //Contrutor
        public DAO(string BancoDeDadosTI13N)
        {
            conexao = new MySqlConnection("server=localhost;DataBase=" + BancoDeDadosTI13N + ";Uid=root;Password=;");
            try
            {
                conexao.Open();//Solicitando a entrada ao banco de dados
                Console.WriteLine("Entrei!!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Algo deu errado!\n\n" + e);
                conexao.Close();//Fechando a conexão com banco de dados
            }//fim da tentativa de conexão com o banco de dados
        }//fim do construtor

        //Criar o método INSERIR
        public void Inserir(long cpf, string nome, string endereco, string telefone, string dataDeNascimento, string login, string senha)
        {
            try
            {
                dados = "('" + cpf + "','" + nome + "','" + endereco + "','" + telefone + "','" + dataDeNascimento + "','" + login + "','" + senha + "')";
                resultado = "Insert into Cliente(cpf, nome, endereco, telefone, dataDeNascimento, login, senha) values" + dados;
                //Executar o comando resultado no banco de dados
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine(resultado + " Linha(s) Afetada(s)!");

            }
            catch (Exception e)
            {
                Console.WriteLine("Algo deu errado!\n\n" + e);
            }//fim do catch
        }//fim do método inserir

        public void PreencherVetor()
        {
            string query = "select * from cliente";//Coletando o dado do BD

            //Instanciando os vetores
            cpf = new long[100];
            nome = new string[100];
            endereco = new string[100];
            telefone = new string[100];
            dataDeNascimento = new string[100];
            login = new string[100];
            senha = new string[100];
            //Dar valores iniciais para ele
            for (i = 0; i < 100; i++)
            {
                cpf[i] = 0;
                nome[i] = "";
                endereco[i] = "";
                telefone[i] = "";
                dataDeNascimento[i] = "";
                login[i] = "";
                senha[i] = "";
            }//fim da repetição

            //Criar o comando para coleta de dados
            MySqlCommand coletar = new MySqlCommand(query, conexao);
            //Usar o comando lendo os dados do banco
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            while (leitura.Read())
            {
                cpf[i] = Convert.ToInt64(leitura["cpf"]);
                nome[i] = leitura["nome"] + "";
                endereco[i] = leitura["telefone"] + "";
                telefone[i] = leitura["endereco"] + "";
                dataDeNascimento[i] = leitura["dataDeNascimento"] + "";
                login[i] = leitura["login"] + "";
                senha[i] = leitura["senha"] + "";
                i++;
                contador++;
            }//fim do while

            //Fechar o dataReader
            leitura.Close();
        }//fim do preencher Vetor

        public string ConsultarTudo()
        {
            //Preencher o vetor
            PreencherVetor();
            msg = "";
            for (long i = 0; i < contador; i++)
            {
                msg += "\n\nCpf: " + cpf[i]
                    + ", Nome: " + nome[i]
                    + ", Endereço: " + telefone[i]
                    + ", Telefone: " + endereco[i]
                    + ", dataDeNascimento: " + dataDeNascimento[i]
                     + ", login: " + login[i]
                      + ", senha: " + senha[i];
            }//fim do for
            return msg;
        }//fim do consultarTudo

        public long ConsultarCpf(long ccpf)
        {
            PreencherVetor();
            for (long i = 0; i < contador; i++)
            {
                if (ccpf == cpf[i])
                {
                    return cpf[i];
                }
            }//fim do for
            return -1;
        }//fim do consultarcpf

        public string ConsultarNome(long ccpf)
        {
            PreencherVetor();
            for (long i = 0; i < contador; i++)
            {
                if (ccpf == cpf[i])
                {
                    return nome[i];
                }
            }//fim do for
            return "Nome não encontrado!";
        }//fim do consultarnome

        public string ConsultarEndereco(long ccpf)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (ccpf == cpf[i])
                {
                    return endereco[i];
                }
            }//fim do for
            return "Endereço não encontrado!";

        }//Fim do consultar endereço

        public string ConsultarTelefone(long ccpf)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (ccpf == cpf[i])
                {
                    return telefone[i];
                }
            }//fim do for
            return "Telefone não encontrado!";





        }//fim do consultar Telefone

        public string ConsultarDataDeNascimento(long ccpf)
        {
            PreencherVetor();
            for (long i = 0; i < contador; i++)
            {
                if (ccpf == cpf[i])
                {
                    return dataDeNascimento[i];
                }
            }//fim do for
            return "Data de Nascimento não encontrado!";


        } // fim de data de nascimento

        public string ConsultarLogin(long ccpf)
        {
            PreencherVetor();
            for (long i = 0; i < contador; i++)
            {
                if (ccpf == cpf[i])
                {
                    return login[i];
                }
            }//fim do for
            return "Login não encontrado!";


        } // fim de data de login


        public string ConsultarSenha(long ccpf)
        {
            PreencherVetor();
            for (long i = 0; i < contador; i++)
            {
                if (ccpf == cpf[i])
                {
                    return senha[i];
                }
            }//fim do for
            return "Senha não encontrado!";


        } // fim de data de senha

        public void Atualizar(string campo, string novoDado, long codigo)
        {
            try
            {
                resultado = "update pessoa set " + campo + " = '" +
                            novoDado + "' where codigo = '" + codigo + "'";
                //Executar o script
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine("Dado Atualizado com Sucesso!");
            }

            catch (Exception e)
            {

                Console.WriteLine("Algo deu errado!" + e);

            }//fim do atualizar

        }


            public void Deletar(long cpf)
            {

                resultado = "delete from pessoa where codigo = '" + cpf + "'";
                //Executar o comando
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                //Mensagem...
                Console.WriteLine("Dados Excluídos com sucesso!");
               

            } //fim do deletar



        
    }//fim da classe
}//fim do projeto
