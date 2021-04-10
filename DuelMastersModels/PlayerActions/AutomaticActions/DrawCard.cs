namespace DuelMastersModels.PlayerActions.AutomaticActions
{
    internal class DrawCard : AutomaticAction
    {
        internal DrawCard(IPlayer player) : base(player)
        {
        }

        internal override PlayerAction Perform(Duel duel)
        {
            return duel.DrawCard(Player);
        }
    }
}
