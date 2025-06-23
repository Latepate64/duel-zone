using TriggeredAbilities;

namespace Cards.DM12
{
    sealed class PharziTheOracle : Creature
    {
        public PharziTheOracle() : base("Pharzi, the Oracle", 2, 1000, Interfaces.Race.LightBringer, Interfaces.Civilization.Light)
        {
            AddTriggeredAbility(new WhenThisCreatureIsDestroyedAbility(new OneShotEffects.YouMayReturnSpellFromYourGraveyardToYourHandEffect()));
        }
    }
}
