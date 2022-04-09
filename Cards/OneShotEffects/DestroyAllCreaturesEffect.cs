using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class DestroyAllCreaturesEffect : DestroyAreaOfEffect
    {
        public DestroyAllCreaturesEffect() : base(new CardFilters.BattleZoneCreatureFilter())
        {
        }

        public override IOneShotEffect Copy()
        {
            return new DestroyAllCreaturesEffect();
        }

        public override string ToString()
        {
            return "Destroy all creatures.";
        }

        protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return game.BattleZone.Creatures;
        }
    }
}