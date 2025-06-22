using TriggeredAbilities;

namespace Cards.DM06
{
    sealed class SkullcutterSwarmLeader : Engine.Creature
    {
        public SkullcutterSwarmLeader() : base("Skullcutter, Swarm Leader", 4, 4000, Interfaces.Race.DevilMask, Interfaces.Civilization.Darkness)
        {
            AddTriggeredAbility(new AtTheEndOfYourTurnIfThisIsYourOnlyCreatureInTheBattleZoneDestroyItAbility(new OneShotEffects.DestroyThisCreatureEffect()));
        }
    }
}
