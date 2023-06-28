using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class ChooseCreaturesInTheBattleZoneAndReturnItToItsOwnersHandEffect : BounceEffect
    {
        public ChooseCreaturesInTheBattleZoneAndReturnItToItsOwnersHandEffect() : base(1, 1)
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
            return "Choose a creature in the battle zone and return it to its owner's hand.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetChoosableCreaturesControlledByAnyone(game, Applier);
        }
    }
}
