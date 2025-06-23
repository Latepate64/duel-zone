using TriggeredAbilities;

namespace Cards.DM02
{
    sealed class WynTheOracle : Creature
    {
        public WynTheOracle() : base("Wyn, the Oracle", 2, 1500, Interfaces.Race.LightBringer, Interfaces.Civilization.Light)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new OneShotEffects.YouMayLookAtOneOfYourOpponentsShieldsEffect()));
        }
    }
}
