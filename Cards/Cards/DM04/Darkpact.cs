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

        public override void Apply()
        {
            var cards = Applier.ChooseAnyNumberOfCards(Applier.ManaZone.Cards, ToString()).ToArray();
            Game.Move(Ability, ZoneType.ManaZone, ZoneType.Graveyard, cards);
            Applier.DrawCards(cards.Length, Ability);
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
