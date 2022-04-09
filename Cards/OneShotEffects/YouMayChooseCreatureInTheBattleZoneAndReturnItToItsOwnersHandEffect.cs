using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class YouMayChooseCreatureInTheBattleZoneAndReturnItToItsOwnersHandEffect : BounceEffect
    {
        public YouMayChooseCreatureInTheBattleZoneAndReturnItToItsOwnersHandEffect() : base(0, 1)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new YouMayChooseCreatureInTheBattleZoneAndReturnItToItsOwnersHandEffect();
        }

        public override string ToString()
        {
            return "You may choose a creature in the battle zone and return it to its owner's hand.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetChoosableCreaturesControlledByAnyone(game, source.GetOpponent(game).Id);
        }
    }
}