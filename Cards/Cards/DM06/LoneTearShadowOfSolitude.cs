using Common;

namespace Cards.Cards.DM06
{
    class LoneTearShadowOfSolitude : Creature
    {
        public LoneTearShadowOfSolitude() : base("Lone Tear, Shadow of Solitude", 1, 2000, Engine.Subtype.Ghost, Civilization.Darkness)
        {
            AddTriggeredAbility(new TriggeredAbilities.AtTheEndOfYourTurnIfThisIsYourOnlyCreatureInTheBattleZoneDestroyItAbility());
        }
    }
}
