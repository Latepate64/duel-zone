using TriggeredAbilities;

namespace Cards.DM09
{
    sealed class Quakesaur : Engine.Creature
    {
        public Quakesaur() : base("Quakesaur", 5, 3000, Interfaces.Race.RockBeast, Interfaces.Civilization.Fire)
        {
            AddTriggeredAbility(new WheneverThisCreatureIsAttackingYourOpponentAndIsNotBlockedAbility(new OneShotEffects.YourOpponentChoosesCardInHisManaZoneAndPutsItIntoHisGraveyardEffect()));
        }
    }
}
