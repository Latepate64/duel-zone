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

        public UntapItAfterItBattlesEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            game.AddDelayedTriggeredAbility(new AfterBattleDelayedTriggeredAbility(new UntapThisCreatureEffect(), Ability));
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
