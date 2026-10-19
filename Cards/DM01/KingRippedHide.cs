using TriggeredAbilities;
using OneShotEffects;
using Interfaces;

namespace Cards.DM01;

sealed class KingRippedHide : Creature
{
    public KingRippedHide() : base("King Ripped-Hide", 7, 5000, Race.Leviathan,
        Civilization.Water)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new YouMayDrawCardsEffect(2)));
    }
}