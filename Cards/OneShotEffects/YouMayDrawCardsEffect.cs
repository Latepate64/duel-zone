using Engine;
using Engine.Abilities;
using Common.Choices;

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
            var player = source.GetController(game);
            if (player != null)
            {
                var decision = player.Choose(new YesNoChoice(source.Controller, "You may draw a card."), game);
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
