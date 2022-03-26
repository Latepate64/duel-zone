namespace Cards.Cards.DM01
{
    class UrthPurifyingElemental : Creature
    {
        public UrthPurifyingElemental() : base("Urth, Purifying Elemental", 6, 6000, Common.Subtype.AngelCommand, Common.Civilization.Light)
        {
            AddAbilities(new StaticAbilities.DoubleBreakerAbility(), new TriggeredAbilities.AtTheEndOfYourTurnAbility(new OneShotEffects.YouMayUntapThisCreatureEffect()));
        }
    }
}
