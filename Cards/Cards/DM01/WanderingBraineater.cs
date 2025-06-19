using Cards.ContinuousEffects;

namespace Cards.Cards.DM01
{
    class WanderingBraineater : Engine.Creature
    {
        public WanderingBraineater() : base("Wandering Braineater", 2, 2000, Engine.Race.LivingDead, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
