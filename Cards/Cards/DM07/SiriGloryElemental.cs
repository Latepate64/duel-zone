using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM07
{
    class SiriGloryElemental : Creature
    {
        public SiriGloryElemental() : base("Siri, Glory Elemental", 6, 7000, Engine.Subtype.AngelCommand, Civilization.Light)
        {
            AddDoubleBreakerAbility();
            AddStaticAbilities(new WhileYouHaveNoShieldsEffect(new StaticAbilities.BlockerAbility(), new TriggeredAbilities.AtTheEndOfYourTurnAbility(new OneShotEffects.YouMayUntapThisCreatureEffect())));
        }
    }
}
