using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;

namespace DuelMastersCards.Resolvables
{
    public class ControllerMayDrawCardResolvable : Resolvable
    {
        public ControllerMayDrawCardResolvable() : base() { }

        public ControllerMayDrawCardResolvable(ControllerMayDrawCardResolvable ability) : base(ability)
        {
        }

        public override Resolvable Copy()
        {
            return new ControllerMayDrawCardResolvable(this);
        }

        public override Choice Resolve(Duel duel, Decision decision)
        {
            if (decision == null)
            {
                return new YesNoChoice(Controller);
            }
            if ((decision as YesNoDecision).Decision)
            {
                duel.GetPlayer(Controller).DrawCards(1, duel);
            }
            return null;
        }
    }
}
