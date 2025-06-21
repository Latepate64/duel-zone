namespace Cards.DM06
{
    class EnergyStream : Engine.Spell
    {
        public EnergyStream() : base("Energy Stream", 3, Engine.Civilization.Water)
        {
            AddSpellAbilities(new OneShotEffects.DrawTwoCardsEffect());
        }
    }
}
