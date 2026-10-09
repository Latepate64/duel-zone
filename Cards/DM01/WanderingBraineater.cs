using Abilities.Static;
using ContinuousEffects.CannotAttack;

namespace Cards.DM01
{
    sealed class WanderingBraineater : Creature
    {
        public WanderingBraineater() : base("Wandering Braineater", 2, 2000, Interfaces.Race.LivingDead, Interfaces.Civilization.Darkness)
        {
            AddAbilities(new BlockerAbility());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
