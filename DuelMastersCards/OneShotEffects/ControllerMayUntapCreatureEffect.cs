using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;

namespace DuelMastersCards.OneShotEffects
{
    public class ControllerMayUntapCreatureEffect : OneShotEffect
    {
        public ControllerMayUntapCreatureEffect()
        {
        }

        public ControllerMayUntapCreatureEffect(ControllerMayUntapCreatureEffect effect) : base(effect)
        {
        }

        public override OneShotEffect Copy()
        {
            return new ControllerMayUntapCreatureEffect(this);
        }

        public override void Apply(Game game)
        {
            var player = game.GetPlayer(Controller);
            var decision = player.Choose(new YesNoChoice(Controller));
            if (decision.Decision)
            {
                game.GetCard(Source).Tapped = false;
            }
        }
    }
}
