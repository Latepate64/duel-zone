using Engine;
using Engine.Abilities;
using Engine.GameEvents;

namespace Cards.TriggeredAbilities
{
    class WheneverYourOpponentUsesTheShieldTriggerAbilityOfOneOfHisShieldsAbility : TriggeredAbility
    {
        public WheneverYourOpponentUsesTheShieldTriggerAbilityOfOneOfHisShieldsAbility(IOneShotEffect effect) : base(effect)
        {
        }

        public WheneverYourOpponentUsesTheShieldTriggerAbilityOfOneOfHisShieldsAbility(WheneverYourOpponentUsesTheShieldTriggerAbilityOfOneOfHisShieldsAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is ShieldTriggerEvent e && e.Player == Controller.Opponent;
        }

        public override IAbility Copy()
        {
            return new WheneverYourOpponentUsesTheShieldTriggerAbilityOfOneOfHisShieldsAbility(this);
        }

        public override string ToString()
        {
            return $"Whenever your opponent uses the \"shield trigger\" ability of one of his shields, {GetEffectText()}";
        }
    }
}
