using TriggeredAbilities;
using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM01;

public sealed class PoisonousMushroom : Creature
{
    public PoisonousMushroom() : base("Poisonous Mushroom", 2, 1000, Race.BalloonMushroom, Civilization.Nature)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
            new YouMayPutUpToCardsFromYourHandIntoYourManaZoneEffect(1)));
    }
}
