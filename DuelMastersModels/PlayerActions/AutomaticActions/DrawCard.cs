namespace DuelMastersModels.PlayerActions.AutomaticActions
{
    public class DrawCard : AutomaticAction
    {
        public DrawCard(Player player) : base(player)
        {
        }

        public override PlayerAction Perform(Duel duel)
        {
            return Duel.DrawCard(Player);
        }
    }
}
