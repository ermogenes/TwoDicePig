namespace TwoDicePig
{
    public class Jogo
    {
        public Jogador Humano { get; private set; }
        public Jogador Kevin { get; private set; }
        public Jogador JogadorAtual { get; private set; }
        public Jogo(string nomeJogadorHumano)
        {
            Humano = new Jogador(nomeJogadorHumano);
            Kevin = new Jogador("Kevin");
            JogadorAtual = SorteiaJogadorInicial();
        }
        private Jogador SorteiaJogadorInicial()
        {
            // Rola um dado para cada jogador
            int resultadoHumano = Humano.Rolar();
            int resultadoKevin = Kevin.Rolar();

            // Se forem iguais, repete
            while (resultadoHumano == resultadoKevin)
            {
                resultadoHumano = Humano.Rolar();
                resultadoKevin = Kevin.Rolar();
            }

            // O maior dado é o do jogador inicial
            if (resultadoKevin > resultadoHumano)
            {
                return Kevin;
            }
            return Humano;
        }
        public ResultadoJogada JogaRodadaAtual()
        {
            // Rola dois dados
            int rolagem1 = JogadorAtual.Rolar();
            int rolagem2 = JogadorAtual.Rolar();

            ResultadoJogada resultado = new ResultadoJogada
            {
                Dado1 = rolagem1,
                Dado2 = rolagem2,
                // Se tirar algum 1, passa a vez
                DevePassarAVez = rolagem1 == 1 || rolagem2 == 1,
                // Se tirar tudo 1, perde toda a pontuação
                PerdeTudo = rolagem1 == 1 && rolagem2 == 1,
            };

            // Se tirou algum 1 não pontua, senão pontua a soma dos dados
            if (resultado.DevePassarAVez)
                resultado.PontosNaJogada = 0;
            else
                resultado.PontosNaJogada = resultado.Dado1 + resultado.Dado2;

            return resultado;
        }
        public void PassaAVez()
        {
            // Alterna o jogador atual
            JogadorAtual = JogadorAtual == Humano ? Kevin : Humano;
        }
        public int DiferencaPontos()
        {
            return JogadorAtual.Placar - PlacarJogadorAdversario();
        }
        public int PlacarJogadorAdversario()
        {
            return JogadorAtual == Humano ? Kevin.Placar : Humano.Placar;
        }
        public bool JogadorAtualEhHumano()
        {
            return JogadorAtual == Humano;
        }
        public bool JogadorAtualVenceu(int placarQueTeraSePassarAVez)
        {
            return placarQueTeraSePassarAVez >= 100;
        }
    }
}