namespace Cards.DM12
{
    sealed class SpectralHornGlitalis : Creature
    {
        public SpectralHornGlitalis() : base("Spectral Horn Glitalis", 3, 4000, [Interfaces.Race.HornedBeast, Interfaces.Race.RainbowPhantom], Interfaces.Civilization.Light, Interfaces.Civilization.Nature)
        {
        }
    }
}
