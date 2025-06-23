namespace Cards.DM06
{
    sealed class EnergyStream : Spell
    {
        public EnergyStream() : base("Energy Stream", 3, Interfaces.Civilization.Water)
        {
            AddSpellAbilities(new OneShotEffects.DrawTwoCardsEffect());
        }
    }
}
