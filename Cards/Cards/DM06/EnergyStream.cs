namespace Cards.Cards.DM06
{
    class EnergyStream : Spell
    {
        public EnergyStream() : base("Energy Stream", 3, Engine.Civilization.Water)
        {
            AddSpellAbilities(new OneShotEffects.DrawCardsEffect(2));
        }
    }
}
