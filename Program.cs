namespace TwoDicePig
{
    class Program
    {
        static void Main(string[] args)
        {
            UI.ExibeTelaInicial();

            // Inicia o jogo
            Jogo jogo = new Jogo(UI.ObtemNomeJogadorHumano());
            UI.ExibeJogadorInicial(jogo.JogadorAtual == jogo.Kevin);

            // Pontuação da rodada é controlada por aqui, não na Classe Jogo
            int pontuacaoNaRodada = 0;

            // Repete as jogadas enquanto o jogo não terminar
            while (true)
            {
                // Tela da jogada
                UI.ExibeInicioNovaJogada(
                    jogo.JogadorAtual.Nome,
                    jogo.JogadorAtual.Placar,
                    jogo.PlacarJogadorAdversario(),
                    pontuacaoNaRodada
                );

                // Faz as rolagens da jogada
                ResultadoJogada jogada = jogo.JogaRodadaAtual();

                // Se o jogador atual perdeu tudo, ele zera a pontuação #TODO
                if (jogada.PerdeTudo)
                {
                    jogo.JogadorAtual.Zerar();
                }

                // Se ele tem que passar, ele não pontuará nessa rodada
                // Caso contrário, sim
                if (jogada.DevePassarAVez)
                    pontuacaoNaRodada = 0;
                else
                    pontuacaoNaRodada += jogada.PontosNaJogada;
                
                // Mantém a pontuação do jogador se ele não tirar nenhum 1 até passar 
                int placarTemporario = jogo.JogadorAtual.Placar + pontuacaoNaRodada;

                // Informa o usuário da situação atual
                UI.ExibeRolagens(jogada.Dado1, jogada.Dado2);
                UI.ExibeResultadoRolagens(jogada.PerdeTudo, jogada.PontosNaJogada);

                // Verifica o final de jogo
                if (jogo.JogadorAtualVenceu(placarTemporario))
                {
                    // Efetiva a pontuação, pois o jogo finalizará
                    jogo.JogadorAtual.Pontuar(pontuacaoNaRodada);

                    // Exibe o placar final
                    UI.ExibePlacarFinal(
                        jogo.JogadorAtual.Nome,
                        jogo.JogadorAtual.Placar,
                        jogo.PlacarJogadorAdversario()
                    );

                    // Exibe a tela de vitória/derrota
                    if (jogo.JogadorAtualEhHumano())
                        UI.ExibeVitoriaHumano();
                    else
                        UI.ExibeVitoriaKevin();
                    
                    // Não há mais jogadas, então sai do loop
                    break;
                }

                // Avalia se o jogador passa vez
                bool jogadorVaiPassarAVez;
                if (jogada.DevePassarAVez)
                {
                    // Foi forçado a passar a vez
                    jogadorVaiPassarAVez = true;
                }
                else
                {
                    // Tem a opção de passar a vez ou continuar

                    // Calcula jogada ótima
                    bool estimadorRecomendaContinuar = Estimador.RecomendaContinuar(
                        placarTemporario,
                        pontuacaoNaRodada,
                        jogo.PlacarJogadorAdversario()
                    );

                    if (!jogo.JogadorAtualEhHumano())
                    {
                        // Kevin sempre segue a jogada ótima
                        jogadorVaiPassarAVez = !estimadorRecomendaContinuar;
                    }
                    else
                    {
                        // Humano vê recomendação e placar atual
                        UI.ExibePlacarCasoPasseAVez(placarTemporario, jogo.PlacarJogadorAdversario());
                        UI.ExibeRecomendacao(estimadorRecomendaContinuar);

                        // Jogador escolhe sua opção
                        jogadorVaiPassarAVez = UI.ObtemDecisaoPassar();
                    }
                }   

                if (jogadorVaiPassarAVez)
                {
                    // Ao passar a vez, a pontuação da rodada acumula no placar
                    // É zero nos casos de passe forçado
                    jogo.JogadorAtual.Pontuar(pontuacaoNaRodada);

                    // Exibe situação da jogada
                    UI.ExibeFinalJogada(
                        jogo.JogadorAtual.Placar,
                        jogo.DiferencaPontos()
                    );

                    // Passa a vez
                    jogo.PassaAVez();

                    // Zera a pontuação da rodada
                    pontuacaoNaRodada = 0;
                }
                else
                {
                    UI.Aguarda();
                }
            }

            // Fim!
            UI.ExibeFinalJogo();
        }
    }
}
