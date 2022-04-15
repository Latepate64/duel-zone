namespace Cards.Cards.DM06
{
    class SkullcutterSwarmLeader : Creature
    {
        public SkullcutterSwarmLeader() : base("Skullcutter, Swarm Leader", 4, 4000, Engine.Subtype.DevilMask, Engine.Civilization.Darkness)
        {
            AddTriggeredAbility(new TriggeredAbilities.AtTheEndOfYourTurnIfThisIsYourOnlyCreatureInTheBattleZoneDestroyItAbility());
        }
    }
}
