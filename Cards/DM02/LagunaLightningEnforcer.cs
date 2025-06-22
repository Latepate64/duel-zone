using TriggeredAbilities;

namespace Cards.DM02
{
    sealed class LagunaLightningEnforcer : Engine.Creature
    {
        public LagunaLightningEnforcer() : base("Laguna, Lightning Enforcer", 5, 2500, Interfaces.Race.Berserker, Interfaces.Civilization.Light)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new OneShotEffects.SearchSpellEffect()));
        }
    }
}
