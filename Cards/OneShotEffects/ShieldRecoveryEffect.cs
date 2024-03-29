﻿using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    abstract class ShieldRecoveryEffect : CardSelectionEffect
    {
        public bool CanUseShieldTrigger { get; }

        protected ShieldRecoveryEffect(ShieldRecoveryEffect effect) : base(effect)
        {
        }

        protected ShieldRecoveryEffect(int minimum, int maximum, bool controllerChooses, bool canUseShieldTrigger) : base(minimum, maximum, controllerChooses)
        {
            CanUseShieldTrigger = canUseShieldTrigger;
        }

        /// <summary>
        /// Must choose one of own shields.
        /// </summary>
        /// <param name="canUseShieldTrigger"></param>
        protected ShieldRecoveryEffect(bool canUseShieldTrigger, int amonunt) : this(amonunt, amonunt, true, canUseShieldTrigger)
        {
        }

        protected override void Apply(IGame game, IAbility source, params ICard[] cards)
        {
            game.PutFromShieldZoneToHand(cards, CanUseShieldTrigger, Ability);
        }
    }

    class ShieldRecoveryCannotUseShieldTriggerEffect : ShieldRecoveryEffect
    {
        public ShieldRecoveryCannotUseShieldTriggerEffect() : base(false, 1)
        {
        }

        public ShieldRecoveryCannotUseShieldTriggerEffect(ShieldRecoveryEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ShieldRecoveryCannotUseShieldTriggerEffect(this);
        }

        public override string ToString()
        {
            return "Choose one of your shields and put it into your hand. You can't use the \"shield trigger\" ability of that shield.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return Controller.ShieldZone.Cards;
        }
    }

    class ShieldRecoveryCanUseShieldTriggerEffect : ShieldRecoveryEffect
    {
        public ShieldRecoveryCanUseShieldTriggerEffect() : base(true, 1)
        {
        }

        public ShieldRecoveryCanUseShieldTriggerEffect(ShieldRecoveryEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ShieldRecoveryCanUseShieldTriggerEffect(this);
        }

        public override string ToString()
        {
            return "Choose one of your shields and put it into your hand.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return Controller.ShieldZone.Cards;
        }
    }
}
