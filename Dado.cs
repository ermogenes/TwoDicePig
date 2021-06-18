using System;

namespace TwoDicePig
{
    public class Dado
    {
        private Random _gerador;
        public Dado()
        {
            _gerador = new Random();
        }
        public int Rolar()
        {
            return _gerador.Next(1, 7);
        }
    }
}