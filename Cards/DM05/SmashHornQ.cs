using ContinuousEffects;
using Engine.Abilities;

namespace Cards.DM05
{
    class SmashHornQ : Engine.Creature
    {
        public SmashHornQ() : base("Smash Horn Q", 3, 2000, [Interfaces.Race.Survivor, Interfaces.Race.HornedBeast], Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new SurvivorEffect(new StaticAbility(new ThisCreatureGetsPowerEffect(1000))));
        }
    }
}
