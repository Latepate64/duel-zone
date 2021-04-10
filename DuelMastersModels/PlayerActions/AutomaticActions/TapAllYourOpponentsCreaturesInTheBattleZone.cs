namespace DuelMastersModels.PlayerActions.AutomaticActions
{
    internal class TapAllYourOpponentsCreaturesInTheBattleZone : AutomaticAction
    {
        internal TapAllYourOpponentsCreaturesInTheBattleZone(IPlayer player) : base(player) { }

        internal override IPlayerAction Perform(IDuel duel)
        {
            foreach (Cards.BattleZoneCreature creature in Player.Opponent.BattleZone.UntappedCreatures)
            {
                creature.Tapped = true;
            }
            return null;
        }
    }
}