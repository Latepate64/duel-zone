using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Collections.Generic;

namespace Cards.ContinuousEffects
{
    class SurvivorEffect : AbilityAddingEffect
    {
        public SurvivorEffect(SurvivorEffect effect) : base(effect)
        {
        }

        public SurvivorEffect(IAbility ability) : base(ability)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new SurvivorEffect(this);
        }

        public override string ToString()
        {
            return $"Survivor : {AbilitiesAsText}";
        }

        protected override IEnumerable<ICard> GetAffectedCards(IGame game)
        {
            return game.BattleZone.GetCreatures(GetController(game).Id, Subtype.Survivor);
        }
    }
}