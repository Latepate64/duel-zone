using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class LookEffect : CardSelectionEffect
    {
        public LookEffect(CardSelectionEffect effect) : base(effect)
        {
        }

        public LookEffect(CardFilter filter, int minimum, int maximum, bool controllerChooses) : base(filter, minimum, maximum, controllerChooses)
        {
        }

        public override OneShotEffect Copy()
        {
            return new LookEffect(this);
        }

        public override string ToString()
        {
            return $"Look at {GetAmountAsText()} of {Filter}. Then put them back where they were.";
        }

        protected override void Apply(IGame game, IAbility source, params ICard[] cards)
        {
            game.GetPlayer(source.Owner).Look(cards);
        }
    }
}