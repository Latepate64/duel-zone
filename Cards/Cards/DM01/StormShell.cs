using Abilities.Triggered;
using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class StormShell : Engine.Creature
    {
        public StormShell() : base("Storm Shell", 7, 2000, Engine.Race.ColonyBeetle, Engine.Civilization.Nature)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new YourOpponentChoosesOneOfHisCreaturesInTheBattleZoneAndPutsItIntoHisManaZoneEffect()));
        }
    }
}
