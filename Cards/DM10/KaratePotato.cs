using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM10;

sealed class KaratePotato : Creature
{
    public KaratePotato() : base("Karate Potato", 4, 1000, Interfaces.Race.WildVeggies, Interfaces.Civilization.Nature)
    {
        AddShieldTrigger();
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
            new YouMayPutUpToCardsFromYourHandIntoYourManaZoneEffect(2)));
    }
}
