using Abilities.Triggered;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM12
{
    class PharziTheOracle : Engine.Creature
    {
        public PharziTheOracle() : base("Pharzi, the Oracle", 2, 1000, Engine.Race.LightBringer, Engine.Civilization.Light)
        {
            AddTriggeredAbility(new WhenThisCreatureIsDestroyedAbility(new OneShotEffects.YouMayReturnSpellFromYourGraveyardToYourHandEffect()));
        }
    }
}
