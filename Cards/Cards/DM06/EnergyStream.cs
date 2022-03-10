using Common;

namespace Cards.Cards.DM06
{
    class EnergyStream : Spell
    {
        public EnergyStream() : base("Energy Stream", 3, Civilization.Water)
        {
            AddAbilities(new Engine.Abilities.SpellAbility(new OneShotEffects.DrawEffect(2)));
        }
    }
}
