using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM11
{
    class RiseAndShine : Spell
    {
        public RiseAndShine() : base("Rise and Shine", 4, Civilization.Light, Civilization.Water)
        {
            AddShieldTrigger();
            AddSpellAbilities(new RiseAndShineEffect());
        }
    }

    class RiseAndShineEffect : OneShotEffect
    {
        public RiseAndShineEffect()
        {
        }

        public RiseAndShineEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply()
        {
            var cards = Applier.RevealTopCardsOfDeck(4);
            var blockers = cards.Where(x => x.IsBlocker());
            var chosen = Applier.ChooseCard(blockers, ToString());
            Game.Move(Ability, ZoneType.Deck, ZoneType.Hand, chosen);
            Applier.PutOnTheBottomOfDeckInAnyOrder(cards.Where(x => x != chosen).ToArray());
        }

        public override IOneShotEffect Copy()
        {
            return new RiseAndShineEffect(this);
        }

        public override string ToString()
        {
            return "Reveal the top 4 cards of your deck. Put one of them that has \"blocker\" into your hand, and put the rest on the bottom of your deck in any order.";
        }
    }
}
