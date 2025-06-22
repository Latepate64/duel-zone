using TriggeredAbilities;

namespace Cards.DM08
{
    sealed class QuixoticHeroSwineSnout : Engine.Creature
    {
        public QuixoticHeroSwineSnout() : base("Quixotic Hero Swine Snout", 2, 1000, Interfaces.Race.BeastFolk, Interfaces.Civilization.Nature)
        {
            AddTriggeredAbility(new WheneverAnotherCreatureIsPutIntoTheBattleZoneAbility(new OneShotEffects.ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(3000)));
        }
    }
}
