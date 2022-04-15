using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class StormShell : Creature
    {
        public StormShell() : base("Storm Shell", 7, 2000, Engine.Subtype.ColonyBeetle, Common.Civilization.Nature)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new YourOpponentChoosesOneOfHisCreaturesInTheBattleZoneAndPutsItIntoHisManaZoneEffect());
        }
    }
}
