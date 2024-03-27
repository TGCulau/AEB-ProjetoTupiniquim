using System.Runtime.Intrinsics.X86;

namespace AEB_ProjetoTupiniquim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cabecalho();                                                
            Console.Write("                                                 Digite seu nome: ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            string nome = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\n                                           Escolha seu pronome de tratamento:\n                                           1. Dra.\n                                           2. Dr.\n                                           Sua Opção: ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            int opt = Convert.ToInt32(Console.ReadLine());
            string nomecentro = "", ptratamento = "";
            int espacos;
            if (opt == 1)
            {
                nomecentro = $"Bem-vinda Dra.{nome}";
                ptratamento = $"Dra.{nome}";
            }
            else if (opt == 2)
            {
                nomecentro = $"Bem-vindo Dr.{nome}";
                ptratamento = $"Dr.{nome}";
            }
            Cabecalho();
            espacos = (Console.WindowWidth - nomecentro.Length) / 2;
            Console.Write(new string(' ', espacos) + nomecentro);
            int op = 0;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("\n\n\nOs valores digitados para a área equivalem as extremidades superior e direita.\nO canto inferior esquerdo considere X = 0 e Y = 0\n");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                int areax = LerInt("\n\nPor favor insira a largura (X) da area onde o robô está: ");
                int areay = LerInt("\nPor favor insira a altura (Y) da area onde o robô está: ");
                int posx, posy;
                while (true)
                {
                    posx = LerInt("\nPor favor insira a posição horizontal (X) inicial do robô: ");
                    if (posx > areax)
                    {
                        Console.Write("\nComando inválido. Por favor insira uma posição que esteja dentro da largura informada (Area X).\n\nPrecione Qualquer tecla para continuar.\n");
                        Console.ReadLine();
                        continue;
                    }
                    break;
                }

                while (true)
                {
                    posy = LerInt("\nPor favor insira a posição vertical (Y) inicial do robô: ");
                    if (posy > areay)
                    {
                        Console.Write("\nComando inválido. Por favor insira uma posição que esteja dentro da altura informada (Area Y).\n\nPrecione Qualquer tecla para continuar.\n");
                        Console.ReadLine();
                        continue;
                    }
                    break;
                }
                string cardeal = "";
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("\nO robô movimenta-se apenas 90º por vez.\nOs valores digitados para a área equivalem as extremidades superior e direita.\nO canto inferior esquerdo considere X = 0 e Y = 0\nIremos trabalhar com apenas quatro posições cardeias, Norte (N), Leste (L), Sul (S) e Oeste (O).");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("\n\nPor favor insira qual coordenação cardeal inicial o robô está: ");
                    
                    cardeal = Console.ReadLine();
                    if (cardeal != "N" && cardeal != "n" && cardeal != "S" && cardeal != "s" && cardeal != "L" && cardeal != "l" && cardeal != "O" && cardeal != "o")
                    {
                        Console.Write("\nComando inválido. Por favor insira uma coordenção cardeal correta conforme descrito.\n\nPrecione Qualquer tecla para continuar.\n");
                        Console.ReadLine();
                        continue;
                    }
                    break;
                }
                

                while (true)
                {
                    string dados = $"Area X:{areax} Area Y:{areay} Posição X:{posx} Posição Y:{posy} Cardeal:{cardeal}";
                    Cabecalho2(espacos, ptratamento, dados);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("\nO robô recebe dois tipos de comando, girar na base e movimentar-se.\n\nPara fazer o robô girar na base para a esquerda basta digitar");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(" E");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write(", já para girar para a direita basta digitar");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(" D");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write(".\nPara fazer o robô movimentar-se basta digitar");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(" M");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write(" e então ele andará 1 posição para frente.\n\n");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    string atencao = "Atenção!!!";
                    espacos = (Console.WindowWidth - atencao.Length) / 2;
                    Console.WriteLine(new string(' ', espacos) + atencao);
                    Console.WriteLine("Caso os comandos excedam a área informada ocorrerá um erro. Sendo necessário informar a sequência de comandos novamente.\n\n");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Por favor, insira a sequencia de comandos para o robô.");
                    Console.Write("Comandos: ");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    string frasecomando = Console.ReadLine();

                    string auxcar = "";
                    int cont = 0, verificarerro = 0;
                    string[] conterro = new string[frasecomando.Length];

                    foreach (char comando in frasecomando)
                    {
                        cont++;
                        if (comando == 'E' || comando == 'e')
                        {
                            if (cardeal == "N" || cardeal == "n")
                            {
                                auxcar = "O";
                            }
                            else if (cardeal == "O" || cardeal == "o")
                            {
                                auxcar = "S";
                            }
                            else if (cardeal == "S" || cardeal == "s")
                            {
                                auxcar = "L";
                            }
                            else if (cardeal == "L" || cardeal == "l")
                            {
                                auxcar = "N";
                            }
                            cardeal = auxcar;
                        }
                        else if (comando == 'D' || comando == 'd')
                        {
                            if (cardeal == "N" || cardeal == "n")
                            {
                                auxcar = "L";
                            }
                            else if (cardeal == "L" || cardeal == "l")
                            {
                                auxcar = "S";
                            }
                            else if (cardeal == "S" || cardeal == "s")
                            {
                                auxcar = "O";
                            }
                            else if (cardeal == "O" || cardeal == "O")
                            {
                                auxcar = "N";
                            }
                            cardeal = auxcar;
                        }
                        if (comando == 'M' || comando == 'm')
                        {
                            if (cardeal == "N" || cardeal == "n")
                            {
                                posy++;
                            }
                            else if (cardeal == "L" || cardeal == "l")
                            {
                                posx++;
                            }
                            else if (cardeal == "S" || cardeal == "s")
                            {
                                posy--;
                            }
                            else if (cardeal == "O" || cardeal == "O")
                            {
                                posx--;
                            }
                        }
                        else if (comando != 'M' && comando != 'm' && comando != 'D' && comando != 'd' && comando != 'E' && comando != 'e')
                        {
                            conterro[cont] = Convert.ToString(comando);
                            verificarerro = 1;
                        }
                    }

                    if (verificarerro == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        string erro = "ERRO";
                        espacos = (Console.WindowWidth - erro.Length) / 2;
                        Console.WriteLine(new string(' ', espacos) + erro);
                        Console.Write($"\n{ptratamento} os comandos");
                        for (int i = 0; i < cont; i++)
                        {
                            Console.Write($" conterro[cont] ");
                        }
                        Console.Write("estão errados, por favor, digite apenas comandos validos \"E\", \"D\" e \"M\".\n\n Precione qualquer tecla para reiniciar o programa.");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }

                    if (posx > areax || posx < 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        string erro = "ERRO";
                        espacos = (Console.WindowWidth - erro.Length) / 2;
                        Console.WriteLine(new string(' ', espacos) + erro);
                        Console.Write($"\n{ptratamento} a quantidade de comandos excede a largura da área determinada.\n\n Precione qualquer tecla para reiniciar o programa.");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }

                    if (posy > areay || posy < 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        string erro = "ERRO";
                        espacos = (Console.WindowWidth - erro.Length) / 2;
                        Console.WriteLine(new string(' ', espacos) + erro);
                        Console.Write($"\n{ptratamento} a quantidade de comandos excede a largura da área determinada.\n\n Precione qualquer tecla para reiniciar o programa.");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    dados = $"Area X:{areax} Area Y:{areay} Posição X:{posx} Posição Y:{posy} Cardeal:{cardeal}";
                    Cabecalho2(espacos, ptratamento, dados);
                    dados = $"Area X:{areax} Area Y:{areay} ";
                    Console.Write("\nA atual posição do robô é:");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write($"\n\n Posição X:{posx} Posição Y:{posy} Cardeal:{cardeal}");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;

                    op = LerInt($"\n\n{ptratamento} o que deseja fazer?\n\n1. Inserir novos comandos\n2. Inserir novos dados\n3. Sair\nSua opção: ");
                    if (op == 1)
                    {
                        continue;
                    }

                    break;
                }
                if (op == 2)
                {
                    continue;
                }
                break;
            }
        }
        static void Cabecalho()
        {
            Console.Clear(); 
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("########################################################################################################################");
            Console.WriteLine("###                                                                                                                  ###");
            Console.Write("###                                           ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Agencia Espacial Brasileira                                            ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.Write("###                                               ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Projeto Tupiniquim I                                               ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("########################################################################################################################\n\n");
        }
        static void Cabecalho2(int espacos, string ptratamento, string dados)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("########################################################################################################################");
            Console.WriteLine("###                                                                                                                  ###");
            Console.Write("###                                           ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Agencia Espacial Brasileira                                            ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.Write("###                                               ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Projeto Tupiniquim I                                               ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("########################################################################################################################\n");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            espacos = (Console.WindowWidth - ptratamento.Length) / 2;
            Console.WriteLine(new string(' ', espacos) + ptratamento);
            espacos = (Console.WindowWidth - dados.Length) / 2;
            Console.WriteLine(new string(' ', espacos) + dados);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\n\n");
        }
        static int LerInt(string texto)
        {
            while (true)
            {
                Console.Write(texto);
                var digitouNumero = int.TryParse(Console.ReadLine(), out var numero);

                if (digitouNumero)
                {
                    return numero;
                }

                Console.Write("\nPor favor digite um numero.\n\nPrecione qualquer tecla para continuar.");
                Console.ReadLine();
                Cabecalho();
            }
        }
    }
}