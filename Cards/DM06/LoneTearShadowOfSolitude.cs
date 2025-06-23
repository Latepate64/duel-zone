using TriggeredAbilities;

namespace Cards.DM06
{
    sealed class LoneTearShadowOfSolitude : Creature
    {
        public LoneTearShadowOfSolitude() : base("Lone Tear, Shadow of Solitude", 1, 2000, Interfaces.Race.Ghost, Interfaces.Civilization.Darkness)
        {
            AddTriggeredAbility(new AtTheEndOfYourTurnIfThisIsYourOnlyCreatureInTheBattleZoneDestroyItAbility(new OneShotEffects.DestroyThisCreatureEffect()));
        }
    }
}
