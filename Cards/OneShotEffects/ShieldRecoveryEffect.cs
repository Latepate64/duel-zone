using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class ShieldRecoveryEffect : CardSelectionEffect
    {
        public bool CanUseShieldTrigger { get; }

        public ShieldRecoveryEffect(CardSelectionEffect effect) : base(effect)
        {
        }

        public ShieldRecoveryEffect(CardFilter filter, int minimum, int maximum, bool controllerChooses, bool canUseShieldTrigger) : base(filter, minimum, maximum, controllerChooses)
        {
            CanUseShieldTrigger = canUseShieldTrigger;
        }

        public ShieldRecoveryEffect(bool canUseShieldTrigger) : this(new CardFilters.OwnersShieldZoneCardFilter(), 1, 1, true, canUseShieldTrigger)
        {

        }

        public override OneShotEffect Copy()
        {
            return new ShieldRecoveryEffect(this);
        }

        protected override void Apply(Game game, Ability source, IEnumerable<Card> cards)
        {
            game.PutFromShieldZoneToHand(cards, CanUseShieldTrigger);
        }

        public override string ToString() //choose one of your shields and put it into your hand. You can't use the "shield trigger" ability of that shield.
        {
            var triggerText = CanUseShieldTrigger ? "" : " \"Shield trigger\" abilities of those shields can't be used.";
            return $"{(ControllerChooses ? "put" : "your opponent puts")} {GetAmountAsText()} {Filter} into their owner's hand.{triggerText}";
        }
    }
}
