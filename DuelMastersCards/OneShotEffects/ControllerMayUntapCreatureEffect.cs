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

        public ControllerMayUntapCreatureEffect(ControllerMayUntapCreatureEffect effect)
        {
        }

        public override OneShotEffect Copy()
        {
            return new ControllerMayUntapCreatureEffect(this);
        }

        public override void Apply(Game game, Ability source)
        {
            var player = game.GetPlayer(source.Owner);
            var decision = player.Choose(new YesNoChoice(source.Owner));
            if (decision.Decision)
            {
                game.GetCard(source.Source).Tapped = false;
            }
        }
    }
}
