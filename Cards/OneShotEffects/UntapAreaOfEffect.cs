using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.OneShotEffects
{
    abstract class UntapAreaOfEffect : OneShotAreaOfEffect
    {
        protected UntapAreaOfEffect(CardFilter filter) : base(filter)
        {
        }

        protected UntapAreaOfEffect(UntapAreaOfEffect effect) : base(effect)
        {
        }

        public override object Apply(IGame game, IAbility source)
        {
            game.GetPlayer(source.Owner).Untap(game, GetAffectedCards(game, source).ToArray());
            return true;
        }
    }
}
