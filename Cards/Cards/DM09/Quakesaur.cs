using Abilities.Triggered;

namespace Cards.Cards.DM09
{
    class Quakesaur : Engine.Creature
    {
        public Quakesaur() : base("Quakesaur", 5, 3000, Engine.Race.RockBeast, Engine.Civilization.Fire)
        {
            AddTriggeredAbility(new WheneverThisCreatureIsAttackingYourOpponentAndIsNotBlockedAbility(new OneShotEffects.YourOpponentChoosesCardInHisManaZoneAndPutsItIntoHisGraveyardEffect()));
        }
    }
}
