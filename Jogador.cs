namespace TwoDicePig
{
    public class Jogador
    {
        public string Nome { get; private set; }
        public int Placar { get; private set; }
        private Dado _dado = new Dado();
        public Jogador(string nome)
        {
            Nome = nome;
            Zerar();
        }
        public int Rolar()
        {
            return _dado.Rolar();
        }
        public void Pontuar(int pontos)
        {
            Placar += pontos;
        }
        public void Zerar()
        {
            Placar = 0;
        }
    }
}