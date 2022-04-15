using Common;

namespace Cards.Cards.DM02
{
    class WynTheOracle : Creature
    {
        public WynTheOracle() : base("Wyn, the Oracle", 2, 1500, Engine.Subtype.LightBringer, Civilization.Light)
        {
            AddWheneverThisCreatureAttacksAbility(new OneShotEffects.YouMayLookAtOneOfYourOpponentsShieldsEffect());
        }
    }
}
