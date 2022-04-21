using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class DestroyThisCreatureEffect : DestroyAreaOfEffect
    {
        public DestroyThisCreatureEffect() : base()
        {
        }

        public DestroyThisCreatureEffect(DestroyAreaOfEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new DestroyThisCreatureEffect(this);
        }

        public override string ToString()
        {
            return "Destroy this creature.";
        }

        protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
        {
            var creature = game.GetCard(source.Source);
            if (creature != null)
            {
                return new ICard[] { creature };
            }
            else
            {
                return System.Array.Empty<ICard>();
            }
        }
    }
}
