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

        public override void Resolve(Duel duel)
        {
            var player = duel.GetPlayer(Controller);
            var decision = player.Choose(new YesNoChoice(Controller));
            if (decision.Decision)
            {
                duel.GetPermanent(Source).Tapped = false;
            }
        }
    }
}
