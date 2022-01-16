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

        public override void Resolve(Duel duel, Decision decision)
        {
            if (decision == null)
            {
                duel.SetAwaitingChoice(new YesNoChoice(Controller));
            }
            else if ((decision as YesNoDecision).Decision)
            {
                duel.GetPermanent(Source).Tapped = false;
            }
        }
    }
}
