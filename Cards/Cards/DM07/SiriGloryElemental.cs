using Cards.ContinuousEffects;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM07
{
    class SiriGloryElemental : Creature
    {
        public SiriGloryElemental() : base("Siri, Glory Elemental", 6, 7000, Engine.Race.AngelCommand, Engine.Civilization.Light)
        {
            AddDoubleBreakerAbility();
            AddStaticAbilities(new SiriEffect());
        }
    }

    class SiriEffect : WhileYouHaveNoShieldsEffect
    {
        public SiriEffect() : base(new StaticAbilities.BlockerAbility(), new TriggeredAbilities.AtTheEndOfYourTurnAbility(new OneShotEffects.YouMayUntapThisCreatureEffect()))
        {
        }

        public SiriEffect(IContinuousEffect effect) : base(effect)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new SiriEffect(this);
        }
    }
}
