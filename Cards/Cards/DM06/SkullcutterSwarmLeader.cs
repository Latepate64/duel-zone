namespace Cards.Cards.DM06
{
    class SkullcutterSwarmLeader : Engine.Creature
    {
        public SkullcutterSwarmLeader() : base("Skullcutter, Swarm Leader", 4, 4000, Engine.Race.DevilMask, Engine.Civilization.Darkness)
        {
            AddTriggeredAbility(new TriggeredAbilities.AtTheEndOfYourTurnIfThisIsYourOnlyCreatureInTheBattleZoneDestroyItAbility());
        }
    }
}
