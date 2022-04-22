using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class KingRippedHide : Creature
    {
        public KingRippedHide() : base("King Ripped-Hide", 7, 5000, Engine.Race.Leviathan, Engine.Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new YouMayDrawUpToTwoCardsEffect());
        }
    }
}
