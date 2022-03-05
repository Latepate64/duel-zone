using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    public class AuroraOfReversalEffect : ChooseAnyNumberOfCardsEffect
    {
        public AuroraOfReversalEffect() : base(new CardFilters.OwnersShieldZoneCardFilter())
        {
        }

        public AuroraOfReversalEffect(AuroraOfReversalEffect effect) : base(effect)
        {
        }

        public override OneShotEffect Copy()
        {
            return new AuroraOfReversalEffect(this);
        }

        public override string ToString()
        {
            return "Choose any number of your shields and put them into your mana zone.";
        }

        protected override void Apply(Game game, Ability source, params Card[] cards)
        {
            game.Move(Common.ZoneType.ShieldZone, Common.ZoneType.ManaZone, cards);
        }
    }
}