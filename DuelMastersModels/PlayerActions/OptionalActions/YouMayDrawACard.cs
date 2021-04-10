namespace DuelMastersModels.PlayerActions.OptionalActions
{
    /// <summary>
    /// Player may draw a card.
    /// </summary>
    public class YouMayDrawACard : OptionalAction
    {
        internal YouMayDrawACard(IPlayer player) : base(player) { }

        internal override PlayerAction Perform(IDuel duel, bool takeAction)
        {
            return takeAction ? new AutomaticActions.DrawCard(Player) : null;
        }
    }
}
