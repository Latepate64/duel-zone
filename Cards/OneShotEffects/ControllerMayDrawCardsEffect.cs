using Engine;
using Engine.Abilities;
using Common.Choices;

namespace Cards.OneShotEffects
{
    public class ControllerMayDrawCardsEffect : OneShotEffect
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

        public override OneShotEffect Copy()
        {
            return new ControllerMayDrawCardsEffect(this);
        }

        public override void Apply(Game game, Ability source)
        {
            var player = game.GetPlayer(source.Owner);
            if (player != null)
            {
                var decision = player.Choose(new YesNoChoice(source.Owner, "You may draw a card."));
                if (decision.Decision)
                {
                    player.DrawCards(1, game);
                    if (++_drawn < Maximum)
                    {
                        Apply(game, source);
                    }
                }
            }
        }

        public override string ToString()
        {
            return Maximum == 1 ? "you may draw a card." : $"you may draw up to {Maximum} cards.";
        }
    }
}
