namespace Cards.Cards.DM08
{
    class GachackMechanicalDoll : TurboRushCreature
    {
        public GachackMechanicalDoll() : base("Gachack, Mechanical Doll", 3, 2000, Engine.Subtype.DeathPuppet, Engine.Civilization.Darkness)
        {
            AddTurboRushAbility(new TriggeredAbilities.WheneverThisCreatureIsAttackingYourOpponentAndIsNotBlockedAbility(new OneShotEffects.YouMayDestroyCreatureEffect()));
        }
    }
}
