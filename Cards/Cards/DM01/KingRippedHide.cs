using TriggeredAbilities;
using OneShotEffects;

namespace Cards.Cards.DM01
{
    class KingRippedHide : Engine.Creature
    {
        public KingRippedHide() : base("King Ripped-Hide", 7, 5000, Engine.Race.Leviathan, Engine.Civilization.Water)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new YouMayDrawUpToTwoCardsEffect()));
        }
    }
}
