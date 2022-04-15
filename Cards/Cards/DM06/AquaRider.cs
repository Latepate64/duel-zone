namespace Cards.Cards.DM06
{
    class AquaRider : Creature
    {
        public AquaRider() : base("Aqua Rider", 4, 2000, Engine.Subtype.LiquidPeople, Engine.Civilization.Water)
        {
            AddTriggeredAbility(new TriggeredAbilities.OpponentSummonOrCastAbility(new OneShotEffects.ThisCreatureGetsBlockerUntilTheEndOfTheTurnOneShotEffect()));
        }
    }
}
