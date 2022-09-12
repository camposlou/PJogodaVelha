using System;
using System.Collections.Generic;

namespace PJogodaVelha
{
    internal class Program
    {
        static string ColetarNome(int n)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Informe o nome do {n + 1} jogador: ");
            string nome = Console.ReadLine();
            return nome;
        }
        static void ImprimeNome(string[] Vetor)
        {
            for (int lin = 0; lin < 2; lin++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"O nome da posição {lin + 1} é: {Vetor[lin]}");
            }
        }
        static void ImprimirGanhador(string turno)
        {
            Console.WriteLine("\n------------------------------------");
            Console.Write($"\n O Ganhador [{turno}] venceu. Parabéns!");
            Console.WriteLine("\n------------------------------------");
            Console.WriteLine("Fim de jogo!!!");

        }
        static void ImprimirjogodaVelha()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("_____________________");
            Console.WriteLine("     JOGO DA VELHA   ");
            Console.WriteLine("_____________________");

        }
        static void Main(string[] args)
        {
            string[] Nome = new string[2];

            string[,] matriz = new string[3, 3];          // > 1° passo - declarei a matriz 3/3

            string opção = "X";                           // > 2° passo - adicionar os turnos "X" "O"

            List<string> IndexNumeros = new List<string> { };   // 5° passo - 

            int index = 1;    // numero dentro das casas de 1 á 9      3° passo - numeros dentro das casas

            int tentativas = 1;   //****** Começa no zero              4° passo - declarar as tentativas

            ImprimirjogodaVelha();

            for (int lin = 0; lin < 2; lin++)
            {
                Nome[lin] = ColetarNome(lin);
            }
            ImprimeNome(Nome);

            // 1° parte -  Alimentando a matriz - Posiçôes
            for (int lin = 0; lin < 3; lin++)              //Lendo as linhas = posiçôes     // int pq é o valor que será acrescentado, é uma variável interna que será usada somente dentro do for
            {
                for (int col = 0; col < 3; col++)           //Lendo as colunas = posiçôes
                {
                    matriz[lin, col] = index.ToString();
                    IndexNumeros.Add(index.ToString());    //5° passo depois de declarar list //Lista com todo a numeração válida do jogo.

                    index++;                               // para coloxcar os numeros dentro das casas de 1 á 9
                }
            }
            //2° parte - Lendo a matriz - o indice
            for (int lin = 0; lin < 3; lin++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Write($" [{matriz[lin, col]}] ");     //$ permite colocar o valor das variáveis dentro da matriz.       
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"VOCÊ QUER JOGAR [{opção}] EM QUAL POSIÇÃO? ");       // turno = cadeia de caracteres - string no inicio do jogo

            string jogada = Console.ReadLine(); //Lê a jogada e executa

            Console.Clear();

            // 3° parte - Começa o jogo
            while (tentativas < 9)   //*********  termina no 9
            {
                ImprimirjogodaVelha();

                for (int lin = 0; lin < 3; lin++)
                {
                    for (int col = 0; col < 3; col++)
                    {                                                                  //Neste "for" estou validando minha "string jogada", se o valor digitado estiver dentro da matriz;
                        if (matriz[lin, col] == jogada && IndexNumeros.Contains(jogada)) // ou seja, estou substituindo o valor na sua respectiva casa. por exemplo:
                                                                                         // digitei 5 e tem a casa 5, substitui por X ou O. mas o valor 5 ainda fica la
                        {
                            matriz[lin, col] = opção;
                            IndexNumeros.Remove(jogada);                      // por isso indexnumeros. Remove - para remover aquele valor. assim o usuario nao poderá digitar 5 novamente
                        }
                    }
                }
                for (int lin = 0; lin < 3; lin++)
                {
                    for (int col = 0; col < 3; col++)                                   // neste "for" estou desenhando minha matriz novamente.
                    {
                        Console.Write($" [{matriz[lin, col]}] ");
                    }
                    Console.WriteLine();
                }
                // 6° parte Condição de vitória
                if (matriz[0, 0] == matriz[1, 1] && matriz[1, 1] == matriz[2, 2] ||       // Condições de vitória na diagonal
                    matriz[0, 2] == matriz[1, 1] && matriz[1, 1] == matriz[2, 0])
                {
                    ImprimirGanhador(opção);
                    break;
                }
                if (matriz[0, 0] == matriz[0, 1] && matriz[0, 1] == matriz[0, 2] ||       // Condições de vitória na horizontal
                     matriz[1, 0] == matriz[1, 1] && matriz[1, 1] == matriz[1, 2] ||
                     matriz[2, 0] == matriz[2, 1] && matriz[2, 1] == matriz[2, 2])
                {
                    ImprimirGanhador(opção);
                    break;
                }
                if (matriz[0, 0] == matriz[1, 0] && matriz[1, 0] == matriz[2, 0] ||
                    matriz[0, 1] == matriz[1, 1] && matriz[1, 1] == matriz[2, 1] ||        //Condições de vitória na vertical
                    matriz[0, 2] == matriz[1, 2] && matriz[1, 2] == matriz[2, 2])
                {
                    ImprimirGanhador(opção);
                    break;
                }
                // 4° parte
                if (opção == "X")                                                     // Trocando jogadas > primeiro "X", depois "O", assim por diante.
                {
                    opção = "O";
                }
                else
                {
                    opção = "X";
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Você quer jogar [{opção}] em qual posição? ");
                jogada = Console.ReadLine();

                // 5° parte - Condição para opção inválida     // Se o numero que eu digitei não estiver na lista, ou seja, já foi digitado ou se digitar uma letra. ele fica no while até digitar um valor valido
                while (!IndexNumeros.Contains(jogada))         // Add para anular jogadas repetidas ou inválidas de acordo com a lista.  (!) = sinal de negação
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Jogada Inválida. Tente novamente: ");
                    jogada = Console.ReadLine();
                }
                tentativas++;
                Console.Clear();
            }
            // 7° parte - condição de empate
            if (tentativas == 9)
            {
                ImprimirjogodaVelha();

                for (int lin = 0; lin < 3; lin++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        Console.Write($" [{matriz[lin, col]}] ");
                    }
                    Console.WriteLine();
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("---------------");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nEMPATE!!    ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("---------------");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("  FIM DE JOGO. ");
            }
            Console.ReadLine();
        }
    }

}