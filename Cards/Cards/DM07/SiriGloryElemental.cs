using Cards.ContinuousEffects;

namespace Cards.Cards.DM07
{
    class SiriGloryElemental : Creature
    {
        public SiriGloryElemental() : base("Siri, Glory Elemental", 6, 7000, Engine.Race.AngelCommand, Engine.Civilization.Light)
        {
            AddDoubleBreakerAbility();
            AddStaticAbilities(new WhileYouHaveNoShieldsEffect(new StaticAbilities.BlockerAbility(), new TriggeredAbilities.AtTheEndOfYourTurnAbility(new OneShotEffects.YouMayUntapThisCreatureEffect())));
        }
    }
}
