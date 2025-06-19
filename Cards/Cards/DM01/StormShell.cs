using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class StormShell : Creature
    {
        public StormShell() : base("Storm Shell", 7, 2000, Engine.Race.ColonyBeetle, Engine.Civilization.Nature)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new YourOpponentChoosesOneOfHisCreaturesInTheBattleZoneAndPutsItIntoHisManaZoneEffect()));
        }
    }
}
