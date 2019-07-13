namespace DuelMastersModels.PlayerActions.OptionalActions
{
    public class YouMayDrawACard : OptionalAction
    {
        public YouMayDrawACard(Player player) : base(player) { }

        public override PlayerAction Perform(Duel duel, bool takeAction)
        {
            if (takeAction)
            {
                return new AutomaticActions.DrawCard(Player);
            }
            else
            {
                return null;
            }
        }
    }
}
