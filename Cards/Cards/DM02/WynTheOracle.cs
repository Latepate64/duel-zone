using Cards.TriggeredAbilities;

namespace Cards.Cards.DM02
{
    class WynTheOracle : Creature
    {
        public WynTheOracle() : base("Wyn, the Oracle", 2, 1500, Engine.Race.LightBringer, Engine.Civilization.Light)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new OneShotEffects.YouMayLookAtOneOfYourOpponentsShieldsEffect()));
        }
    }
}
