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
        public override void Apply(IGame game, IAbility source)
        {
            var cards = source.GetOpponent(game).Hand.Cards;
            if (cards.Any())
            {
                source.GetController(game).Look(source.GetOpponent(game), game, cards.ToArray());
                source.GetOpponent(game).Discard(source, game, cards.Where(x => x.HasCivilization(Civilization.Darkness) && x.CardType == CardType.Spell).ToArray());
                source.GetOpponent(game).Unreveal(cards);
            }
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
