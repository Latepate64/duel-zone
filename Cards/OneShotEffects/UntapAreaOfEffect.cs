using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.OneShotEffects
{
    class UntapAreaOfEffect : OneShotAreaOfEffect
    {
        public UntapAreaOfEffect(CardFilter filter) : base(filter)
        {
        }

        public UntapAreaOfEffect(UntapAreaOfEffect effect) : base(effect)
        {
        }

        public override void Apply(Game game, Ability source)
        {
            game.GetPlayer(source.Owner).Untap(game, GetAffectedCards(game, source).ToArray());
        }

        public override OneShotEffect Copy()
        {
            return new UntapAreaOfEffect(this);
        }

        public override string ToString()
        {
            return $"Untap {Filter}.";
        }
    }
}
