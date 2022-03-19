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

        public override object Apply(IGame game, IAbility source)
        {
            game.GetPlayer(source.Owner).Untap(game, GetAffectedCards(game, source).ToArray());
            return true;
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
