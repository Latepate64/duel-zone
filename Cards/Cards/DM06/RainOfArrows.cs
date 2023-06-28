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
        public RainOfArrowsEffect()
        {
        }

        public RainOfArrowsEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            var cards = Applier.Opponent.Hand.Cards.ToArray();
            if (cards.Any())
            {
                Applier.Look(Applier.Opponent, game, cards);
                Applier.Opponent.Discard(Ability, game, cards.Where(x => x.HasCivilization(Civilization.Darkness) && x.IsSpell).ToArray());
                Applier.Opponent.Unreveal(cards);
            }
        }

        public override IOneShotEffect Copy()
        {
            return new RainOfArrowsEffect(this);
        }

        public override string ToString()
        {
            return "Look at your opponent's hand. He discards all darkness spells from it.";
        }
    }
}
