using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class YouMayDestroyCreatureEffect : DestroyEffect
    {
        public YouMayDestroyCreatureEffect() : base(0, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new YouMayDestroyCreatureEffect();
        }

        public override string ToString()
        {
            return "You may destroy a creature.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetChoosableCreaturesControlledByAnyone(game, source.GetOpponent(game).Id);
        }
    }
}