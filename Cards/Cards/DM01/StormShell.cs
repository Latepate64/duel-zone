using Cards.CardFilters;
using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class StormShell : Creature
    {
        public StormShell() : base("Storm Shell", 7, 2000, Common.Subtype.ColonyBeetle, Common.Civilization.Nature)
        {
            AddAbilities(new WhenThisCreatureIsPutIntoTheBattleZoneAbility(new YourOpponentChoosesOneOfHisCreaturesInTheBattleZoneAndPutsItIntoHisManaZoneEffect()));
        }
    }
}
