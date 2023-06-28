using Cards.TriggeredAbilities;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class UntapItAfterItBattlesEffect : OneShotEffect
    {
        public UntapItAfterItBattlesEffect()
        {
        }

        public UntapItAfterItBattlesEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply()
        {
            Game.AddDelayedTriggeredAbility(new DelayedTriggeredAbility(new AfterBattleAbility(new UntapThisCreatureEffect()), true, Ability));
        }

        public override IOneShotEffect Copy()
        {
            return new UntapItAfterItBattlesEffect(this);
        }

        public override string ToString()
        {
            return "Untap it after it battles.";
        }
    }
}
