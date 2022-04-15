using Common;

namespace Cards.Cards.DM09
{
    class Quakesaur : Creature
    {
        public Quakesaur() : base("Quakesaur", 5, 3000, Engine.Subtype.RockBeast, Civilization.Fire)
        {
            AddTriggeredAbility(new TriggeredAbilities.WheneverThisCreatureIsAttackingYourOpponentAndIsNotBlockedAbility(new OneShotEffects.YourOpponentChoosesCardsInHisManaZoneAndPutsThemIntoHisGraveyardEffect(1)));
        }
    }
}
