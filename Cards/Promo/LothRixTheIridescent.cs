using TriggeredAbilities;

namespace Cards.Promo
{
    class LothRixTheIridescent : EvolutionCreature
    {
        public LothRixTheIridescent() : base("Loth Rix, the Iridescent", 6, 4000, Interfaces.Race.Guardian, Interfaces.Civilization.Light)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.AddTheTopCardOfYourDeckToYourShieldsFaceDownEffect()));
        }
    }
}
