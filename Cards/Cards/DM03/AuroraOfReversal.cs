using Cards.OneShotEffects;
using Common;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM03
{
    class AuroraOfReversal : Spell
    {
        public AuroraOfReversal() : base("Aurora of Reversal", 5, Civilization.Nature)
        {
            AddSpellAbilities(new AuroraOfReversalEffect());
        }
    }

    class AuroraOfReversalEffect : ChooseAnyNumberOfCardsEffect
    {
        public AuroraOfReversalEffect() : base(new CardFilters.OwnersShieldZoneCardFilter())
        {
        }

        public AuroraOfReversalEffect(AuroraOfReversalEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new AuroraOfReversalEffect(this);
        }

        public override string ToString()
        {
            return "Choose any number of your shields and put them into your mana zone.";
        }

        protected override void Apply(IGame game, IAbility source, params Engine.ICard[] cards)
        {
            game.Move(ZoneType.ShieldZone, ZoneType.ManaZone, cards);
        }
    }
}
