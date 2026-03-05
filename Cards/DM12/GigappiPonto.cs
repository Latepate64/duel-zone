namespace Cards.DM12
{
    sealed class GigappiPonto : Creature
    {
        public GigappiPonto() : base("Gigappi Ponto", 3, 4000, [Interfaces.Race.Chimera, Interfaces.Race.FireBird], Interfaces.Civilization.Darkness, Interfaces.Civilization.Fire)
        {
        }
    }
}
