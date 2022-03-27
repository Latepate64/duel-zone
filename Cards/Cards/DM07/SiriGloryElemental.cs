using Common;

namespace Cards.Cards.DM07
{
    class SiriGloryElemental : Creature
    {
        public SiriGloryElemental() : base("Siri, Glory Elemental", 6, 7000, Subtype.AngelCommand, Civilization.Light)
        {
            AddAbilities(new StaticAbilities.DoubleBreakerAbility(), new StaticAbilities.WhileYouHaveNoShieldsAbility(new StaticAbilities.BlockerAbility(), new TriggeredAbilities.AtTheEndOfYourTurnAbility(new OneShotEffects.YouMayUntapThisCreatureEffect())));
        }
    }
}
