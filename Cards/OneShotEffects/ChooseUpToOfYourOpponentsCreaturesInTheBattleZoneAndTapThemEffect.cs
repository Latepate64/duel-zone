﻿using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class ChooseUpToOfYourOpponentsCreaturesInTheBattleZoneAndTapThemEffect : TapChoiceEffect
    {
        private readonly int _amount;

        public ChooseUpToOfYourOpponentsCreaturesInTheBattleZoneAndTapThemEffect(int amount) : base(0, amount, true)
        {
            _amount = amount;
        }

        public ChooseUpToOfYourOpponentsCreaturesInTheBattleZoneAndTapThemEffect(ChooseUpToOfYourOpponentsCreaturesInTheBattleZoneAndTapThemEffect effect) : base(effect)
        {
            _amount = effect._amount;
        }

        public override IOneShotEffect Copy()
        {
            return new ChooseUpToOfYourOpponentsCreaturesInTheBattleZoneAndTapThemEffect(this);
        }

        public override string ToString()
        {
            return $"Choose up to {_amount} of your opponent's creatures in the battle zone and tap them.";
        }
    }
}