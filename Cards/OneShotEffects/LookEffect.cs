using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.OneShotEffects
{
    class LookEffect : CardSelectionEffect
    {
        public LookEffect(LookEffect effect) : base(effect)
        {
        }

        public LookEffect(CardFilter filter, int minimum, int maximum, bool controllerChooses) : base(filter, minimum, maximum, controllerChooses)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new LookEffect(this);
        }

        public override string ToString()
        {
            return $"Look at {GetAmountAsText()} of {Filter}. Then put them back where they were.";
        }

        protected override void Apply(IGame game, IAbility source, params ICard[] cards)
        {
            if (cards.Any())
            {
                var revealer = game.GetOwner(cards.First());
                game.GetPlayer(source.Owner).Look(revealer, game, cards);
                revealer.Unreveal(cards);
            }
        }
    }
}