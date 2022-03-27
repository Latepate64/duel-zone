using Common;

namespace Cards.Cards.DM05
{
    class SolidskinFish : Creature
    {
        public SolidskinFish() : base("Solidskin Fish", 3, 3000, Subtype.Fish, Civilization.Water)
        {
            AddAbilities(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ReturnCardFromYourManaZoneToYourHandEffect()));
        }
    }
}
