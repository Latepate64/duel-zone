using Cards.ContinuousEffects;
using Engine.Abilities;

namespace Cards.Cards.DM05
{
    class SmashHornQ : Creature
    {
        public SmashHornQ() : base("Smash Horn Q", 3, 2000, [Engine.Race.Survivor, Engine.Race.HornedBeast], Engine.Civilization.Nature)
        {
            AddStaticAbilities(new SurvivorEffect(new StaticAbility(new ThisCreatureGetsPowerEffect(1000))));
        }
    }
}
