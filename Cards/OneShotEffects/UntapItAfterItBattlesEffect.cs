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

        public override void Apply(IGame game, IAbility source)
        {
            game.AddDelayedTriggeredAbility(new DelayedTriggeredAbility(new AfterBattleAbility(new UntapThisCreatureEffect()), source.Source, source.Controller, true));
        }

        public override IOneShotEffect Copy()
        {
            return new UntapItAfterItBattlesEffect();
        }

        public override string ToString()
        {
            return "Untap it after it battles.";
        }
    }
}
