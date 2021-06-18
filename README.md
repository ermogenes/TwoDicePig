# TwoDicePig

Uma implementação de TwoDicePig em C# com OOP e IA.

## O Jogo

Cada jogador rola um dado e o jogador com o maior valor joga primeiro. Em caso de empate, repete-se o processo até que o primeiro jogador seja definido.

Os jogadores iniciam com `0` pontos e jogam em rodadas alternadas.

Na sua rodada um jogador rola dois dados de 6 faces:
- Caso role somente um `1` a rodada termina sem pontuar, passando a vez;
- Caso role dois `1`, o placar do jogador volta a `0` e sua rodada termina;
- Caso role dois números diferentes de `1`, os valores dos dados são somados ao placar da rodada e o jogador decide se quer jogar novamente ou terminar a rodada (pontuando os pontos da rodada no seu placar geral);

Ganha quem primeiro alcançar `100` ou mais pontos.

## Inteligência Artificial

Todd Neller e Clifton Presser calcularam a jogada ótima para diversas variações de Pig nos seus estudos listados abaixo.

Para este jogo, usaremos a seguinte regra para decidir entre continuar ou passar:

_Se o meu placar é 71 ou mais, continue. Nos demais casos, continue até que sua mão pontue `21 + inteiro((placar adversário - seu placar) / 8)`._

Isso faz com que se pare em `21` quando empatado, reduzindo esse valor quando está à frente e aumentando quando está atrás.

## Referências:

- [Todd W. Neller and Clifton G.M. Presser. Practical Play of the Dice Game Pig, The UMAP Journal 31(1) (2010), pp. 5–19.](http://cs.gettysburg.edu/~tneller/papers/pig+.pdf)
- [Todd W. Neller and Clifton G.M. Presser. Pigtail: A Pig Addendum, The UMAP Journal 26(4) (2005), pp. 443–458.](http://cs.gettysburg.edu/~tneller/papers/umap10.pdf)
- [Wikipedia - Pig](https://en.wikipedia.org/wiki/Pig_(dice_game))

## Artes
- Emoticons [aqui](https://cutekaomoji.com/) e [aqui](https://www.fastemoji.com/)
- ASCII Art [aqui](https://ascii.co.uk/)
