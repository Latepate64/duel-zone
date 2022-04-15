using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM04
{
    class Darkpact : Spell
    {
        public Darkpact() : base("Darkpact", 2, Engine.Civilization.Darkness)
        {
            AddSpellAbilities(new DarkpactEffect());
        }
    }

    class DarkpactEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var cards = new PutAnyNumberOfCardsFromYourManaZoneIntoYourGraveyard().Apply(game, source);
            new DrawCardsEffect(cards.Count()).Apply(game, source);
            return cards;
        }

        public override IOneShotEffect Copy()
        {
            return new DarkpactEffect();
        }

        public override string ToString()
        {
            return "Put any number of cards from your mana zone into your graveyard. Then draw that many cards.";
        }
    }

    class PutAnyNumberOfCardsFromYourManaZoneIntoYourGraveyard : ChooseAnyNumberOfCardsEffect
    {
        public PutAnyNumberOfCardsFromYourManaZoneIntoYourGraveyard() : base()
        {
        }

        public PutAnyNumberOfCardsFromYourManaZoneIntoYourGraveyard(PutAnyNumberOfCardsFromYourManaZoneIntoYourGraveyard effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new PutAnyNumberOfCardsFromYourManaZoneIntoYourGraveyard(this);
        }

        public override string ToString()
        {
            return "Put any number of cards from your mana zone into your graveyard.";
        }

        protected override void Apply(IGame game, IAbility source, params Engine.ICard[] cards)
        {
            game.Move(ZoneType.ManaZone, ZoneType.Graveyard, cards);
        }

        protected override IEnumerable<Engine.ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return source.GetController(game).ManaZone.Cards;
        }
    }
}
