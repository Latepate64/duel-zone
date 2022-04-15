namespace Cards.Cards.DM10
{
    class FerrosaturnSpectralKnight : Creature
    {
        public FerrosaturnSpectralKnight() : base("Ferrosaturn, Spectral Knight", 1, 2000, Engine.Subtype.RainbowPhantom, Engine.Civilization.Light)
        {
            AddBlockerAbility();
            AddThisCreatureCannotAttackPlayersAbility();
        }
    }
}
