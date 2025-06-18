using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM03
{
    class AuroraOfReversal : Engine.Spell
    {
        public AuroraOfReversal() : base("Aurora of Reversal", 5, Civilization.Nature)
        {
            AddSpellAbilities(new AuroraOfReversalEffect());
        }
    }

    class AuroraOfReversalEffect : ChooseAnyNumberOfCardsEffect
    {
        public AuroraOfReversalEffect() : base()
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

        protected override void Apply(IGame game, IAbility source, params Card[] cards)
        {
            game.Move(Ability, ZoneType.ShieldZone, ZoneType.ManaZone, cards);
        }

        protected override IEnumerable<Card> GetAffectedCards(IGame game, IAbility source)
        {
            return Controller.ShieldZone.Cards;
        }
    }
}
