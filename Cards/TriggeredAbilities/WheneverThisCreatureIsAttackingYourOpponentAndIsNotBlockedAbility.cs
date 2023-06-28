using Engine;
using Engine.Abilities;
using Engine.GameEvents;

namespace Cards.TriggeredAbilities
{
    class WheneverThisCreatureIsAttackingYourOpponentAndIsNotBlockedAbility : TriggeredAbility
    {
        public WheneverThisCreatureIsAttackingYourOpponentAndIsNotBlockedAbility(IOneShotEffect effect) : base(effect)
        {
        }

        public WheneverThisCreatureIsAttackingYourOpponentAndIsNotBlockedAbility(WheneverThisCreatureIsAttackingYourOpponentAndIsNotBlockedAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is BecomeUnblockedEvent e && e.Attacker == Source && game.CurrentTurn.CurrentPhase is Engine.Steps.AttackPhase a && a.AttackTarget == Controller.Opponent;
        }

        public override IAbility Copy()
        {
            return new WheneverThisCreatureIsAttackingYourOpponentAndIsNotBlockedAbility(this);
        }

        public override string ToString()
        {
            return $"Whenever this creature is attacking your opponent and isn't blocked, {GetEffectText()}";
        }
    }
}
