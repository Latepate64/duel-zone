namespace Cards.DM12
{
    sealed class GigappiPonto : Engine.Creature
    {
        public GigappiPonto() : base("Gigappi Ponto", 3, 4000, [Interfaces.Race.Chimera, Interfaces.Race.FireBird], Interfaces.Civilization.Darkness, Interfaces.Civilization.Fire)
        {
        }
    }
}
