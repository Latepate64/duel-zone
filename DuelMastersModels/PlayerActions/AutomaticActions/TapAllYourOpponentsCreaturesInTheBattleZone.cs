namespace DuelMastersModels.PlayerActions.AutomaticActions
{
    internal class TapAllYourOpponentsCreaturesInTheBattleZone : AutomaticAction
    {
        internal TapAllYourOpponentsCreaturesInTheBattleZone(IPlayer player) : base(player) { }

        internal override PlayerAction Perform(IDuel duel)
        {
            foreach (Cards.BattleZoneCreature creature in duel.GetOpponent(Player).BattleZone.UntappedCreatures)
            {
                creature.Tapped = true;
            }
            return null;
        }
    }
}