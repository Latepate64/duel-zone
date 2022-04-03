using Common;

namespace Cards.Cards.DM12
{
    class PharziTheOracle : Creature
    {
        public PharziTheOracle() : base("Pharzi, the Oracle", 2, 1000, Subtype.LightBringer, Civilization.Light)
        {
            AddWhenThisCreatureIsDestroyedAbility(new OneShotEffects.YouMayReturnSpellFromYourGraveyardToYourHandEffect());
        }
    }
}
