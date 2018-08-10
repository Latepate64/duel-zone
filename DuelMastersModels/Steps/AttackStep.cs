using DuelMastersModels.PlayerActions;

namespace DuelMastersModels.Steps
{
    /// <summary>
    /// 505.1. Attack step consists of five substeps: "attack declaration", "block declaration", "battle", "direct attack" and "end of attack".
    /// </summary>
    public class AttackStep : Step
    {
        public AttackStep(Player player) : base(player, "Attack")
        {
        }

        public override PlayerAction PlayerActionRequired()
        {
            return null; //TODO
        }
    }
}
