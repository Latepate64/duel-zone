using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM01;

public sealed class AquaHulcus : Creature
{
    public AquaHulcus() : base("Aqua Hulcus", 3, 2000, Race.LiquidPeople,
        Civilization.Water)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new YouMayDrawCardsEffect(1)));
    }
}