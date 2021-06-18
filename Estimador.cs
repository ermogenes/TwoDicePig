namespace TwoDicePig
{
    public class Estimador
    {
        public static bool RecomendaContinuar(int placar, int placarRodada, int placarAdversario)
        {
            // Após 71 pontos, sempre tente chegar em 100
            if (placar > 71) return true;

            // O objetivo da rodada é 21, ajustado de acordo com o placar do adversário
            int diferencaPlacar = placarAdversario - placar;
            int objetivo = 21 + diferencaPlacar / 8;

            // Se o objetivo foi atingido, passe a vez
            return (placarRodada <= objetivo);
        }
    }
}