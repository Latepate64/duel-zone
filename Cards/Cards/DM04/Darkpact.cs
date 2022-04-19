using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM04
{
    class Darkpact : Spell
    {
        public Darkpact() : base("Darkpact", 2, Civilization.Darkness)
        {
            AddSpellAbilities(new DarkpactEffect());
        }
    }

    class DarkpactEffect : OneShotEffect
    {
        public override void Apply(IGame game, IAbility source)
        {
            var cards = source.GetController(game).ChooseAnyNumberOfCards(source.GetController(game).ManaZone.Cards, ToString()).ToArray();
            game.Move(source, ZoneType.ManaZone, ZoneType.Graveyard, cards);
            new DrawCardsEffect(cards.Length).Apply(game, source);
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
}
