using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;

namespace DuelMastersCards.Resolvables
{
    public class ControllerMayUntapCreatureResolvable : Resolvable
    {
        public ControllerMayUntapCreatureResolvable()
        {
        }

        public ControllerMayUntapCreatureResolvable(ControllerMayUntapCreatureResolvable resolvable) : base(resolvable)
        {
        }

        public override Resolvable Copy()
        {
            return new ControllerMayUntapCreatureResolvable(this);
        }

        public override Choice Resolve(Duel duel, Decision decision)
        {
            if (decision == null)
            {
                return new YesNoChoice(Controller);
            }
            else if ((decision as YesNoDecision).Decision)
            {
                duel.GetPermanent(Source).Tapped = false;
            }
            return null;
        }
    }
}
