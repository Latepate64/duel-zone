using Common;

namespace Cards.Cards.Promo
{
    class LothRixTheIridescent : EvolutionCreature
    {
        public LothRixTheIridescent() : base("Loth Rix, the Iridescent", 6, 4000, Subtype.Guardian, Civilization.Light)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.AddTheTopCardOfYourDeckToYourShieldsFaceDownEffect());
        }
    }
}
