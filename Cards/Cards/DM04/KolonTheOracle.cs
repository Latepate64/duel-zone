using Common;

namespace Cards.Cards.DM04
{
    class KolonTheOracle : Creature
    {
        public KolonTheOracle() : base("Kolon, the Oracle", 4, 1000, Subtype.LightBringer, Civilization.Water)
        {
            ShieldTrigger = true;
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayChooseOneOfYourOpponentsCreaturesAndTapItEffect());
        }
    }
}
