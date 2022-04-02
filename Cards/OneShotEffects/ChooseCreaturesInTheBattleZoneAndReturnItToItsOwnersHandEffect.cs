﻿using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class ChooseCreaturesInTheBattleZoneAndReturnItToItsOwnersHandEffect : BounceEffect
    {
        public ChooseCreaturesInTheBattleZoneAndReturnItToItsOwnersHandEffect(int amount = 1) : base(new CardFilters.BattleZoneChoosableCreatureFilter(), amount, amount)
        {
        }

        public ChooseCreaturesInTheBattleZoneAndReturnItToItsOwnersHandEffect(ChooseCreaturesInTheBattleZoneAndReturnItToItsOwnersHandEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ChooseCreaturesInTheBattleZoneAndReturnItToItsOwnersHandEffect(this);
        }

        public override string ToString()
        {
            return Minimum == 1 ? "Choose a creature in the battle zone and return it to its owner's hand." : $"Choose {Minimum} creatures in the battle zone and return them to their owner's hands.";
        }
    }
}
