using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.OneShotEffects
{
    class ScreamSlicerShadowOfFearEffect : OneShotEffect
    {
        public override void Apply(IGame game, IAbility source)
        {
            var creatures = game.BattleZone.Creatures.Where(x => x.Power == game.BattleZone.Creatures.Min(x => x.Power.Value));
            new ScreamSlicerShadowOfFearDestroyEffect(creatures.ToArray()).Apply(game, source);
        }

        public override IOneShotEffect Copy()
        {
            return new ScreamSlicerShadowOfFearEffect();
        }

        public override string ToString()
        {
            return "Destroy the creature that has the least power in the battle zone. If there's a tie, you choose from among the tied creatures.";
        }
    }

    class ScreamSlicerShadowOfFearDestroyEffect : DestroyEffect
    {
        private readonly ICard[] _cards;

        public ScreamSlicerShadowOfFearDestroyEffect(params ICard[] cards) : base(1, 1, true)
        {
            _cards = cards;
        }

        public ScreamSlicerShadowOfFearDestroyEffect(ScreamSlicerShadowOfFearDestroyEffect effect) : base(effect)
        {
            _cards = effect._cards;
        }

        public override IOneShotEffect Copy()
        {
            return new ScreamSlicerShadowOfFearDestroyEffect(this);
        }

        public override string ToString()
        {
            return "Destroy a creature.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return _cards;
        }
    }
}
