using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class PoisonousMushroom : Creature
    {
        public PoisonousMushroom() : base("Poisonous Mushroom", 2, 1000, Engine.Subtype.BalloonMushroom, Engine.Civilization.Nature)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new YouMayPutUpToCardsFromYourHandIntoYourManaZoneEffect(1));
        }
    }
}
