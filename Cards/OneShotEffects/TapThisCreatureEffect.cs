using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class TapThisCreatureEffect : TapAreaOfEffect
    {
        public TapThisCreatureEffect() : base()
        {
        }

        public override IOneShotEffect Copy()
        {
            return new TapThisCreatureEffect();
        }

        public override string ToString()
        {
            return "Tap this creature.";
        }

        protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return new ICard[] { game.GetCard(source.Source) };
        }
    }
}
