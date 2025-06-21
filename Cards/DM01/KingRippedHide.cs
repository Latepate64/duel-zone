using TriggeredAbilities;
using OneShotEffects;

namespace Cards.DM01
{
    class KingRippedHide : Engine.Creature
    {
        public KingRippedHide() : base("King Ripped-Hide", 7, 5000, Interfaces.Race.Leviathan, Interfaces.Civilization.Water)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new YouMayDrawUpToTwoCardsEffect()));
        }
    }
}
