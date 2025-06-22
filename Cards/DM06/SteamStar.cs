namespace Cards.DM06
{
    sealed class SteamStar : Engine.Creature
    {
        public SteamStar() : base("Steam Star", 2, 1000, Interfaces.Race.CyberVirus, Interfaces.Civilization.Water)
        {
        }
    }
}
