using Common;

namespace Cards.Cards.DM06
{
    class EnergyStream : Spell
    {
        public EnergyStream() : base("Energy Stream", 3, Civilization.Water)
        {
            AddSpellAbilities(new OneShotEffects.DrawEffect(2));
        }
    }
}
