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

        public YouMayDestroyCreatureEffect(DestroyEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new YouMayDestroyCreatureEffect(this);
        }

        public override string ToString()
        {
            return "You may destroy a creature.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IAbility source)
        {
            return Game.BattleZone.GetChoosableCreaturesControlledByAnyone(Applier);
        }
    }
}