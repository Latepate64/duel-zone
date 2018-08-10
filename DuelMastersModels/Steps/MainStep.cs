using DuelMastersModels.PlayerActions;

namespace DuelMastersModels.Steps
{
    /// <summary>
    /// 504.1. Normally, the active player can use cards only during their main step.
    /// </summary>
    public class MainStep : Step
    {
        public MainStep(Player player) : base(player, "Main")
        {
        }

        public override PlayerAction PlayerActionRequired()
        {
            return null; //TODO
        }
    }
}
