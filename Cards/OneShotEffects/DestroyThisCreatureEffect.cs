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
            if (Ability.Source != null)
            {
                return new ICard[] { Ability.Source };
            }
            else
            {
                return System.Array.Empty<ICard>();
            }
        }
    }
}
