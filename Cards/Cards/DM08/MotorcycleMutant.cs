namespace Cards.Cards.DM08
{
    class MotorcycleMutant : Creature
    {
        public MotorcycleMutant() : base("Motorcycle Mutant", 4, 6000, Engine.Subtype.Hedrian, Engine.Civilization.Darkness)
        {
            AddBlockerAbility();
            AddThisCreatureCannotAttackAbility();
            AddTriggeredAbility(new TriggeredAbilities.WhenYouPutAnotherCreatureIntoTheBattleZoneAbility(new OneShotEffects.DestroyThisCreatureEffect()));
        }
    }
}
