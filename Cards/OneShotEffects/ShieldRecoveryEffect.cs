using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    abstract class ShieldRecoveryEffect : CardSelectionEffect
    {
        public bool CanUseShieldTrigger { get; }

        protected ShieldRecoveryEffect(ShieldRecoveryEffect effect) : base(effect)
        {
        }

        protected ShieldRecoveryEffect(CardFilter filter, int minimum, int maximum, bool controllerChooses, bool canUseShieldTrigger) : base(filter, minimum, maximum, controllerChooses)
        {
            CanUseShieldTrigger = canUseShieldTrigger;
        }

        /// <summary>
        /// Must choose one of own shields.
        /// </summary>
        /// <param name="canUseShieldTrigger"></param>
        protected ShieldRecoveryEffect(bool canUseShieldTrigger) : this(new CardFilters.OwnersShieldZoneCardFilter(), 1, 1, true, canUseShieldTrigger)
        {
        }

        protected override void Apply(IGame game, IAbility source, params ICard[] cards)
        {
            game.PutFromShieldZoneToHand(cards, CanUseShieldTrigger);
        }
    }

    class ShieldRecoveryCannotUseShieldTriggerEffect : ShieldRecoveryEffect
    {
        public ShieldRecoveryCannotUseShieldTriggerEffect() : base(false)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ShieldRecoveryCannotUseShieldTriggerEffect();
        }

        public override string ToString()
        {
            return "Choose one of your shields and put it into your hand. You can't use the \"shield trigger\" ability of that shield.";
        }
    }

    class ShieldRecoveryCanUseShieldTriggerEffect : ShieldRecoveryEffect
    {
        public ShieldRecoveryCanUseShieldTriggerEffect() : base(true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ShieldRecoveryCanUseShieldTriggerEffect();
        }

        public override string ToString()
        {
            return "Choose one of your shields and put it into your hand.";
        }
    }
}
