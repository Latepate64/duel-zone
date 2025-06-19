using Abilities.Triggered;

namespace Cards.Cards.DM06
{
    class AquaRider : Engine.Creature
    {
        public AquaRider() : base("Aqua Rider", 4, 2000, Engine.Race.LiquidPeople, Engine.Civilization.Water)
        {
            AddTriggeredAbility(new OpponentSummonOrCastAbility(new OneShotEffects.ThisCreatureGetsBlockerUntilTheEndOfTheTurnOneShotEffect()));
        }
    }
}
