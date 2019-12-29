namespace DuelMastersModels.PlayerActions.AutomaticActions
{
    internal class DrawCard : AutomaticAction
    {
        internal DrawCard(Player player) : base(player)
        {
        }

        internal override PlayerAction Perform(Duel duel)
        {
            return duel.DrawCard(Player);
        }
    }
}
