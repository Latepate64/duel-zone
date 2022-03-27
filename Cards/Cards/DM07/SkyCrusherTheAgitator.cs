using Common;

namespace Cards.Cards.DM07
{
    class SkyCrusherTheAgitator : Creature
    {
        public SkyCrusherTheAgitator() : base("Sky Crusher, the Agitator", 7, 4000, Subtype.Dragonoid, Civilization.Fire)
        {
            AddAbilities(new Engine.Abilities.TapAbility(new OneShotEffects.MutualManaSacrificeEffect(1)));
        }
    }
}
