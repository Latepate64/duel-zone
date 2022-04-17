using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class YouMayDrawCardsEffect : OneShotEffect
    {
        public int Maximum { get; }

        private int _drawn;

        public YouMayDrawCardsEffect(int maximum) : base()
        {
            Maximum = maximum;
        }

        public YouMayDrawCardsEffect(YouMayDrawCardsEffect effect)
        {
            Maximum = effect.Maximum;
        }

        public override IOneShotEffect Copy()
        {
            return new YouMayDrawCardsEffect(this);
        }

        public override object Apply(IGame game, IAbility source)
        {
            if (source.GetController(game).ChooseToTakeAction("You may draw a card."))
            {
                source.GetController(game).DrawCards(1, game, source);
                if (++_drawn < Maximum)
                {
                    Apply(game, source);
                }
            }
            return null;
        }

        public override string ToString()
        {
            return Maximum == 1 ? "You may draw a card." : $"You may draw up to {Maximum} cards.";
        }
    }
}
