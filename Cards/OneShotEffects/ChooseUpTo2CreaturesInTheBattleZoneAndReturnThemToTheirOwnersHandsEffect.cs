using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class ChooseUpTo2CreaturesInTheBattleZoneAndReturnThemToTheirOwnersHandsEffect : BounceEffect
    {
        public ChooseUpTo2CreaturesInTheBattleZoneAndReturnThemToTheirOwnersHandsEffect() : base(0, 2)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ChooseUpTo2CreaturesInTheBattleZoneAndReturnThemToTheirOwnersHandsEffect();
        }

        public override string ToString()
        {
            return "Choose up to 2 creatures in the battle zone and return them to their owners' hands.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetChoosableCreaturesControlledByAnyone(game, source.GetOpponent(game).Id);
        }
    }
}
