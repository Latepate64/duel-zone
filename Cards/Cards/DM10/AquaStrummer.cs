using Cards.OneShotEffects;
using Engine;

namespace Cards.Cards.DM10
{
    class AquaStrummer : Creature
    {
        public AquaStrummer() : base("Aqua Strummer", 3, 2000, Race.LiquidPeople, Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new LookAtTheTopCardsOfYourDeckAndPutBackInAnyOrderEffect(5));
        }
    }
}
