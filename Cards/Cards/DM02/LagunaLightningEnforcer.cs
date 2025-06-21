using TriggeredAbilities;

namespace Cards.Cards.DM02
{
    class LagunaLightningEnforcer : Engine.Creature
    {
        public LagunaLightningEnforcer() : base("Laguna, Lightning Enforcer", 5, 2500, Engine.Race.Berserker, Engine.Civilization.Light)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new OneShotEffects.SearchSpellEffect()));
        }
    }
}
