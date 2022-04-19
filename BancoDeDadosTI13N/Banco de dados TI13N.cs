using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeDadosTI13N
{
    class Menu
    {
        DAO dao;
        Livros livro;
        public int opcao;

        public long cpf;
        public string guardar;
        public string sim;
        public string nao;


        public Menu()
        {
            opcao = 0;
            dao = new DAO("BancoDeDadosTI13N");
            livro = new Livros("BancoDeDadosTI13N");
        }//fim do construtor

        public void MostrarOpcoes()
        {
            Console.WriteLine("\n\nEscolha uma das opções abaixo: \n\n" +
                              "\n1. Cadastrar" +
                              "\n2. Consultar Tudo" +
                              "\n3. Consultar Individual" +
                              "\n4. Atualizar" +
                              "\n5. Excluir" +
                              "\n6. Consultar Livros" +
                              "\n7. Realizar Compra");
                       

         opcao = Convert.ToInt32(Console.ReadLine());
        }//fim do método

        public void Executar()
        {
            do
                {
                    MostrarOpcoes();//Mostrando o menu para o usuário

                switch (opcao)
                {
                    case 1:
                        //Colentando os dados
                        Console.WriteLine("Informe seu cpf: ");
                        long cpf = Convert.ToInt64(Console.ReadLine());
                        Console.WriteLine("\nInforme seu nome: ");
                        string nome = Console.ReadLine();
                        Console.WriteLine("\nInforme seu endereco: ");
                        string endereco = Console.ReadLine();
                        Console.WriteLine("Informe seu telefone: ");
                        string telefone = Console.ReadLine();
                        Console.WriteLine("Informe sua data de nascimento: ");
                        string dataDeNascimento = Console.ReadLine();
                        Console.WriteLine("Informe sua login: ");
                        string login = Console.ReadLine();
                        Console.WriteLine("Informe sua senha: ");
                        string senha = Console.ReadLine();
                        
                        //Executar o método inserir
                        dao.Inserir( cpf, nome, endereco, telefone, dataDeNascimento, login, senha );
                        break;
                    case 2:
                        //Consultar os dados
                        Console.WriteLine(dao.ConsultarTudo());
                        break;

                    case 3:
                        //Consultar Individual
                        Console.WriteLine("Informe o código que deseja consultar");
                         long ccpf = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("cpf: " + dao.ConsultarCpf(ccpf) +
                                          "\nnome: " + dao.ConsultarNome(ccpf) +
                                          "\nEndereço: " + dao.ConsultarEndereco(ccpf) +
                                          "\nTelefone: " + dao.ConsultarTelefone(ccpf) +
                                          "\ndataDeNascimento: " + dao.ConsultarDataDeNascimento(ccpf) +
                                          "\nlogin: " + dao.ConsultarLogin(ccpf) +
                                          "\nsenha: " + dao.ConsultarSenha(ccpf));                                         
                        break;

                    case 4:
                        //Atualizar
                        Console.WriteLine("Qual campo desejas atualizar?");
                        string campo = Console.ReadLine();
                        Console.WriteLine("Qual o novo dado?");
                        string novoDado = Console.ReadLine();
                        Console.WriteLine("Qual o código da pessoa que deseja atualizar?");
                        cpf = Convert.ToInt32(Console.ReadLine());
                        dao.Atualizar(campo, novoDado, cpf);
                        break;
                    case 5:
                        //Deletar
                        Console.WriteLine("Informe o código que deseja deletar");
                        cpf = Convert.ToInt32(Console.ReadLine());
                        //Usar o método da classe DAO
                        dao.Deletar(cpf);
                        break;

                    case 6:
                        //Consultar Individual
                        Console.WriteLine("Informe o código que deseja consultar");
                        int codigo = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("titulo: " + livro.Consultartitulo(codigo) +
                                          "\nano: " + livro.ConsultarAno(codigo) +
                                          "\neditora: " + livro.ConsultarEditora(codigo) +
                                          "\nquantidade: " + livro.ConsultarQuantidade(codigo)); 
                        


                        break;

                    case 7:
                        Console.WriteLine("Dejesa comprar esse livro? SIM/NÃO");
                        Console.ReadLine();
                       if (guardar == sim)
                       {
                            Console.WriteLine("Compra Efetuada com sucesso");

                       }
                       else
                       {
                            Console.WriteLine("");

                       }
                       if (guardar == nao)

                       {
                            Console.WriteLine("Compra Cancelada");
                            
                       }
                       
                       
                        break;

                    case 0:
                        Console.WriteLine("Obrigado!");
                        break;
                    default:
                        Console.WriteLine("Código digitado não é valido!");
                        break;
                }//fim do switch_Case
            } while (opcao != 0);
        }//fim do método



    }//fim da classe
}//fim do projeto
