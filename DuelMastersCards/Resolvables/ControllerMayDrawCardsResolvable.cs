using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;

namespace DuelMastersCards.Resolvables
{
    public class ControllerMayDrawCardsResolvable : Resolvable
    {
        public int Maximum { get; }

        private int _drawn;

        public ControllerMayDrawCardsResolvable(int maximum) : base()
        {
            Maximum = maximum;
        }

        public ControllerMayDrawCardsResolvable(ControllerMayDrawCardsResolvable ability) : base(ability)
        {
            Maximum = ability.Maximum;
        }

        public override Resolvable Copy()
        {
            return new ControllerMayDrawCardsResolvable(this);
        }

        public override void Resolve(Duel duel)
        {
            var player = duel.GetPlayer(Controller);
            var decision = player.Choose(new YesNoChoice(Controller));
            if (decision.Decision)
            {
                player.DrawCards(1, duel);
                if (++_drawn < Maximum)
                {
                    Resolve(duel);
                }
            }
        }
    }
}
