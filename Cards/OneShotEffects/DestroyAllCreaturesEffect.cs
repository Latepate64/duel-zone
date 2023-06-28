using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class DestroyAllCreaturesEffect : DestroyAreaOfEffect
    {
        public DestroyAllCreaturesEffect() : base()
        {
        }

        public DestroyAllCreaturesEffect(DestroyAreaOfEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new DestroyAllCreaturesEffect(this);
        }

        public override string ToString()
        {
            return "Destroy all creatures.";
        }

        protected override IEnumerable<ICard> GetAffectedCards(IAbility source)
        {
            return Game.BattleZone.Creatures;
        }
    }
}