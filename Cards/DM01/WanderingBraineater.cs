using ContinuousEffects;

namespace Cards.DM01
{
    class WanderingBraineater : Engine.Creature
    {
        public WanderingBraineater() : base("Wandering Braineater", 2, 2000, Interfaces.Race.LivingDead, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
