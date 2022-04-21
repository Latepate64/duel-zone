using Engine;
using Engine.Abilities;
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
        public DarkpactEffect()
        {
        }

        public DarkpactEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            var player = GetController(game);
            var cards = player.ChooseAnyNumberOfCards(player.ManaZone.Cards, ToString()).ToArray();
            game.Move(GetSourceAbility(game), ZoneType.ManaZone, ZoneType.Graveyard, cards);
            player.DrawCards(cards.Length, game, GetSourceAbility(game));
        }

        public override IOneShotEffect Copy()
        {
            return new DarkpactEffect(this);
        }

        public override string ToString()
        {
            return "Put any number of cards from your mana zone into your graveyard. Then draw that many cards.";
        }
    }
}
