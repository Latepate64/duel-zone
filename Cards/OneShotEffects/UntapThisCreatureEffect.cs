using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class UntapThisCreatureEffect : UntapAreaOfEffect
    {
        public UntapThisCreatureEffect() : base() { }

        public override IOneShotEffect Copy()
        {
            return new UntapThisCreatureEffect();
        }

        public override string ToString()
        {
            return "Untap this creature.";
        }

        protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return new ICard[] { game.GetCard(source.Source) };
        }
    }
}
