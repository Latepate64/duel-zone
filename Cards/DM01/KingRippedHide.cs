using TriggeredAbilities;
using OneShotEffects;

namespace Cards.DM01
{
    sealed class KingRippedHide : Creature
    {
        public KingRippedHide() : base("King Ripped-Hide", 7, 5000, Interfaces.Race.Leviathan, Interfaces.Civilization.Water)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new YouMayDrawUpToTwoCardsEffect()));
        }
    }
}
