using TriggeredAbilities;
using OneShotEffects;

namespace Cards.DM01
{
    sealed class StormShell : Creature
    {
        public StormShell() : base("Storm Shell", 7, 2000, Interfaces.Race.ColonyBeetle, Interfaces.Civilization.Nature)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new YourOpponentChoosesOneOfHisCreaturesInTheBattleZoneAndPutsItIntoHisManaZoneEffect()));
        }
    }
}
