using Common;

namespace Cards.Cards.DM10
{
    class KaratePotato : Creature
    {
        public KaratePotato() : base("Karate Potato", 4, 1000, Subtype.WildVeggies, Civilization.Nature)
        {
            ShieldTrigger = true;
            AddAbilities(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayPutUpToCardsFromYourHandIntoYourManaZoneEffect(2)));
        }
    }
}
