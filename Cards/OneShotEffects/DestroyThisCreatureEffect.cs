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

        public override IOneShotEffect Copy()
        {
            return new DestroyThisCreatureEffect();
        }

        public override string ToString()
        {
            return "Destroy this creature.";
        }

        protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return new ICard[] { game.GetCard(source.Source) };
        }
    }
}
