using Engine.Abilities;

namespace Cards.DM07
{
    sealed class SkyCrusherTheAgitator : Creature
    {
        public SkyCrusherTheAgitator() : base("Sky Crusher, the Agitator", 7, 4000, Interfaces.Race.Dragonoid, Interfaces.Civilization.Fire)
        {
            AddAbilities(new TapAbility(new OneShotEffects.MutualSingleManaSacrificeEffect()));
        }
    }
}
