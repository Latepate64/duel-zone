using DuelMastersModels;
using DuelMastersModels.Abilities;
using System.Collections.Generic;

namespace DuelMastersCards.OneShotEffects
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

        public override OneShotEffect Copy()
        {
            return new ShieldRecoveryEffect(this);
        }

        protected override void Apply(Game game, Ability source, IEnumerable<Card> cards)
        {
            game.PutFromShieldZoneToHand(cards, CanUseShieldTrigger);
        }
    }
}
