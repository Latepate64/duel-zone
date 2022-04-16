namespace Cards.Cards.DM10
{
    class ZeroNemesisShadowOfPanic : EvolutionCreature
    {
        public ZeroNemesisShadowOfPanic() : base("Zero Nemesis, Shadow of Panic", 6, 6000, Engine.Race.Ghost, Engine.Civilization.Darkness)
        {
            AddTriggeredAbility(new TriggeredAbilities.WheneverAnyOfYourCreaturesAttacksAbility(new OneShotEffects.OpponentRandomDiscardEffect()));
            AddDoubleBreakerAbility();
        }
    }
}
