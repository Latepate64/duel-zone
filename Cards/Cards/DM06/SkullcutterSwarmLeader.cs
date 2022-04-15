using Common;

namespace Cards.Cards.DM06
{
    class SkullcutterSwarmLeader : Creature
    {
        public SkullcutterSwarmLeader() : base("Skullcutter, Swarm Leader", 4, 4000, Engine.Subtype.DevilMask, Civilization.Darkness)
        {
            AddTriggeredAbility(new TriggeredAbilities.AtTheEndOfYourTurnIfThisIsYourOnlyCreatureInTheBattleZoneDestroyItAbility());
        }
    }
}
