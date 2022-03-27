using Cards.TriggeredAbilities;
using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class UntapItAfterItBattlesEffect : OneShotEffect
    {
        public UntapItAfterItBattlesEffect()
        {
        }

        public override object Apply(IGame game, IAbility source)
        {
            game.AddDelayedTriggeredAbility(new AfterBattleAbility(new UntapAreaOfEffect(new TargetFilter())), new Engine.Durations.Once());
            return true;
        }

        public override OneShotEffect Copy()
        {
            return new UntapItAfterItBattlesEffect();
        }

        public override string ToString()
        {
            return "Untap it after it battles.";
        }
    }
}
