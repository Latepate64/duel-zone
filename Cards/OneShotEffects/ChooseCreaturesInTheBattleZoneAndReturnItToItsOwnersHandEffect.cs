using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class ChooseCreaturesInTheBattleZoneAndReturnItToItsOwnersHandEffect : BounceEffect
    {
        public ChooseCreaturesInTheBattleZoneAndReturnItToItsOwnersHandEffect(int amount = 1) : base(amount, amount)
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

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetChoosableCreaturesControlledByAnyone(game, GetOpponent(game).Id);
        }
    }
}
