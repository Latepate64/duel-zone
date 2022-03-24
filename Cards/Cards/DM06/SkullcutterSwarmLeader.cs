using Common;

namespace Cards.Cards.DM06
{
    class SkullcutterSwarmLeader : Creature
    {
        public SkullcutterSwarmLeader() : base("Skullcutter, Swarm Leader", 4, 4000, Subtype.DevilMask, Civilization.Darkness)
        {
            AddAbilities(new TriggeredAbilities.AtTheEndOfYourTurnIfThisIsYourOnlyCreatureInTheBattleZoneDestroyItAbility());
        }
    }
}
