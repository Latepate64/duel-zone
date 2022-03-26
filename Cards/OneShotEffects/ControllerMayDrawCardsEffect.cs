using Engine;
using Engine.Abilities;
using Common.Choices;

namespace Cards.OneShotEffects
{
    class ControllerMayDrawCardsEffect : OneShotEffect
    {
        public int Maximum { get; }

        private int _drawn;

        public ControllerMayDrawCardsEffect(int maximum) : base()
        {
            Maximum = maximum;
        }

        public ControllerMayDrawCardsEffect(ControllerMayDrawCardsEffect effect)
        {
            Maximum = effect.Maximum;
        }

        public override IOneShotEffect Copy()
        {
            return new ControllerMayDrawCardsEffect(this);
        }

        public override object Apply(IGame game, IAbility source)
        {
            var player = game.GetPlayer(source.Owner);
            if (player != null)
            {
                var decision = player.Choose(new YesNoChoice(source.Owner, "You may draw a card."), game);
                if (decision.Decision)
                {
                    player.DrawCards(1, game);
                    if (++_drawn < Maximum)
                    {
                        Apply(game, source);
                    }
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
