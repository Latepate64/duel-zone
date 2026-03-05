using TriggeredAbilities;
using ContinuousEffects;
using OneShotEffects;

namespace Cards.DM06
{
    sealed class FactoryShellQ : Creature
    {
        public FactoryShellQ() : base("Factory Shell Q", 6, 2000, [Interfaces.Race.Survivor, Interfaces.Race.ColonyBeetle], Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new SurvivorEffect(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new SearchRaceCreatureEffect(Interfaces.Race.Survivor))));
        }
    }
}
