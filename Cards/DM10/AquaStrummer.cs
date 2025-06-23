using OneShotEffects;
using TriggeredAbilities;
using Interfaces;

namespace Cards.DM10;

sealed class AquaStrummer : Creature
{
    public AquaStrummer() : base(
        "Aqua Strummer", 3, 2000, Race.LiquidPeople, Civilization.Water)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
            new LookAtTheTopCardsOfYourDeckAndPutBackInAnyOrderEffect(5)));
    }
}
