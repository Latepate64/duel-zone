using TriggeredAbilities;

namespace Cards.DM06
{
    sealed class AquaRider : Creature
    {
        public AquaRider() : base("Aqua Rider", 4, 2000, Interfaces.Race.LiquidPeople, Interfaces.Civilization.Water)
        {
            AddTriggeredAbility(new OpponentSummonOrCastAbility(new OneShotEffects.ThisCreatureGetsBlockerUntilTheEndOfTheTurnOneShotEffect()));
        }
    }
}
