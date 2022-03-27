using Common;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM06
{
    class RainOfArrows : Spell
    {
        public RainOfArrows() : base("Rain of Arrows", 2, Civilization.Light)
        {
            AddSpellAbilities(new RainOfArrowsEffect());
        }
    }

    class RainOfArrowsEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var opponent = game.GetPlayer(game.GetOpponent(source.Controller));
            var cards = opponent.Hand.Cards;
            if (cards.Any())
            {
                game.GetPlayer(source.Controller).Look(opponent, game, cards.ToArray());
                opponent.Discard(game, cards.Where(x => x.Civilizations.Contains(Civilization.Darkness) && x.CardType == CardType.Spell).ToArray());
                opponent.Unreveal(cards);
            }
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new RainOfArrowsEffect();
        }

        public override string ToString()
        {
            return "Look at your opponent's hand. He discards all darkness spells from it.";
        }
    }
}
