using System;
using System.Threading;

namespace TwoDicePig
{
    public class UI
    {
        public static void ExibeTelaInicial()
        {
            Console.ResetColor();
            Console.Clear();
            Console.WriteLine("--- Two Dice Pig ---\n");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("             ____               ________     ,',.`.            ");
            Console.WriteLine("           \\`''-.`-._..--...-'''        ```--':_ ) )           ");
            Console.WriteLine("            `-.._` '              -..           ' /            ");
            Console.WriteLine("     ,'`..__..'' -. _ `._                         \\            ");
            Console.WriteLine("    ('';`      _ ,''       .-'            ,'       :           ");
            Console.WriteLine("     `-._     `*/     ,                  '      .  |           ");
            Console.WriteLine("        _.:._   `-'`-'  ;   \\                  ,'  ;           ");
            Console.WriteLine("     .':::::'`    ,' \\,'     :         ;          /            ");
            Console.WriteLine("      `-..__        ,'/      |       ,'         ,'             ");
            Console.WriteLine("            ``---;'` \\ `     ;.____..-'`.     ,'\\              ");
            Console.WriteLine("                /   / \\:    :            :   (\\ `\\             ");
            Console.WriteLine("              ,'  .'   \\    :           ;'   / )  )            ");
            Console.WriteLine("             /,_,.;::.  `.   \\         /   ,',',_(:::.         ");
            Console.WriteLine("                          `.  `.     ,'  ;'                    ");
            Console.WriteLine("                           /,_,'::. `-'`'::.                   ");
            Console.WriteLine();
            Console.ResetColor();
        }
        public static string ObtemNomeJogadorHumano()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("(`(??)´)");
            Console.ResetColor();
            Console.Write(" => Oi, eu sou o Kevin. Vamos jogar? Qual seu nome ? ");
            return Console.ReadLine().Trim();
        }
        public static void ExibeJogadorInicial(bool kevinPrimeiro)
        {
            UI.Aguarda();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\n(`(??)´) ");
            Console.ResetColor();
            if (kevinPrimeiro)
            {
                Console.WriteLine("=> Eu começo!\n");
            }
            else
            {
                Console.WriteLine("=> Você começa!\n");
            }
            UI.Pausa();
        }
        public static void ExibeInicioNovaJogada(string nome, int placar, int placarAdversario, int placarRodada)
        {
            Console.Write("\n\n--- ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(nome);
            Console.ResetColor();
            Console.Write(" | Placar: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(placar);
            Console.ResetColor();
            Console.Write(" x Adversário: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(placarAdversario);
            Console.ResetColor();
            Console.Write(" | Nesta rodada: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(placarRodada);
            Console.ResetColor();
            Console.WriteLine(" ---");
        }
        public static void ExibeRecomendacao(bool estimativa)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("\n└[¨┌]  └[ ¨ ]┘  [┐¨]┘");
            Console.ResetColor();
            Console.Write(" => Dica: ");
            UI.Aguarda();
            if (estimativa)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("CONTINUAR");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("PASSAR A VEZ");
            }
            Console.WriteLine("\n");
            Console.ResetColor();
        }
        public static void ExibeRolagens(int dado1, int dado2)
        {
            Console.Write("Rolagens => ");
            UI.Aguarda();
            ExibeValorDado(dado1);
            Console.Write(" e");
            UI.Aguarda();
            ExibeValorDado(dado2);
            Console.WriteLine();
        }
        public static void ExibeValorDado(int dado)
        {
            switch (dado)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
            }
            Console.Write(dado);
            Console.ResetColor();
        }
        public static void ExibeFinalJogada(int pontos, int diferencaPontos)
        {
            Console.WriteLine();
            Console.WriteLine($"Terminou a rodada com {pontos} pontos.");
            if (diferencaPontos == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Jogo empatado.");
            }
            else if (diferencaPontos > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Ganhando por {diferencaPontos} ponto(s).");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Perdendo por {Math.Abs(diferencaPontos)} ponto(s).");
            }
            Console.ResetColor();
            Console.WriteLine("\n------------------------------------------\n");
            UI.Pausa();
        }
        public static bool ObtemDecisaoPassar()
        {
            Console.Write("[");
            Console.Write("P");
            Console.Write("]assar a vez | [");
            Console.Write("ENTER");
            Console.Write("] Continuar: ");
            Console.ResetColor();
            return Console.ReadLine().Trim().ToUpper().StartsWith("P");
        }
        public static void ExibeResultadoRolagens(bool perdeuTudo, int pontos)
        {
            if (perdeuTudo)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Perdeu tudo e passou a vez!");
            }
            else if (pontos == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Não fez nenhum ponto e passou a vez.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"Fez {pontos} pontos.");
            }
            Console.ResetColor();
        }
        public static void ExibePlacarCasoPasseAVez(int placar, int placarAdversario)
        {
            Console.Write("Placar caso passe a vez: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(placar);
            Console.ResetColor();
            Console.Write(" x Adversário: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(placarAdversario);
            Console.ResetColor();
        }
        public static void ExibePlacarFinal(string nome, int placar, int placarAdversario)
        {
            UI.Aguarda();
            Console.Write("\n     ---- Placar Final: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(nome);
            Console.ResetColor();
            Console.Write(" venceu por ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(placar);
            Console.ResetColor();
            Console.Write(" a ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(placarAdversario);
            Console.ResetColor();
            Console.WriteLine(". ----\n");
        }
        public static void ExibeVitoriaHumano()
        {
            Console.WriteLine("--- Vitória :) Kevin virou bacon! ---");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("          __      _.._         ");
            Console.WriteLine(".-'__`-._.'.--.'.__.,   ");
            Console.WriteLine("/--'  '-._.'    '-._./   ");
            Console.WriteLine("/__.--._.--._.'``-.__/    ");
            Console.WriteLine("'._.-'-._.-._.-''-..'     ");
            Console.ResetColor();
        }
        public static void ExibeVitoriaKevin()
        {
            Console.WriteLine("--- Derrota :( Olha a carinha de felicidade do Kevin! ---");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                                     _ _       ");
            Console.WriteLine("                                    : * :      ");
            Console.WriteLine("                                     `.'       ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("                              __..             ");
            Console.WriteLine("              __            .'  /__            ");
            Console.WriteLine("   .       .-\"  `--._.---.__`..'-.'            ");
            Console.WriteLine("    \\.-.-.''                    a `-'|         ");
            Console.WriteLine("     `-' |        )            .   .'          ");
            Console.WriteLine("         `       .     `.       `-'            ");
            Console.WriteLine("          \\     .        .     .'              ");
            Console.WriteLine("           `.            :   .'                ");
            Console.WriteLine("             `.  )\"\"\"--\"\"\\ |/ \\                ");
            Console.WriteLine("              | / \\     : ( `\\               ");
            Console.WriteLine("              _/   ^      \\_\\  ^               ");
        }
        public static void ExibeFinalJogo()
        {
            Console.Write("\n\n- ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("(`(??)´)");
            Console.ResetColor();
            Console.WriteLine(" Tchau! Volte sempre!");
        }
        public static void Aguarda()
        {
            Console.Write(".");
            Thread.Sleep(300);
            Console.Write(".");
            Thread.Sleep(300);
            Console.Write(".");
            Thread.Sleep(300);
        }
        public static void Pausa()
        {
            Console.Write("Pressione uma tecla para iniciar a rodada");
            UI.Aguarda();
            Console.ReadKey();
            Console.Clear();
        }
    }
}