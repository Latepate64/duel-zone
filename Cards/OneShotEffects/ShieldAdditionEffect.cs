using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class ShieldAdditionEffect : CardSelectionEffect
    {
        public ShieldAdditionEffect(ShieldAdditionEffect effect) : base(effect)
        {
        }

        public ShieldAdditionEffect(CardFilter filter, int minimum, int maximum, bool controllerChooses) : base(filter, minimum, maximum, controllerChooses)
        {
        }

        public override OneShotEffect Copy()
        {
            return new ShieldAdditionEffect(this);
        }

        public override string ToString()
        {
            return $"Add {GetAmountAsText()} {Filter} to your shields face down.";
        }

        protected override void Apply(IGame game, IAbility source, params ICard[] cards)
        {
            game.Move(Common.ZoneType.Hand, Common.ZoneType.ShieldZone, cards);
        }
    }
}
