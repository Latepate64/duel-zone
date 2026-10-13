using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using CardFilters;

namespace Cards.DM01;

public sealed class PoisonousMushroom : Creature
{
    public PoisonousMushroom() : base("Poisonous Mushroom", 2, 1000,
        Race.BalloonMushroom, Civilization.Nature)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new YouMayPutUpToCardsFromYourHandIntoYourManaZoneEffect(
                    minimum: 0,
                    maximum: 1,
                    filter: new AnyCardFilter()
        )));
    }
}
