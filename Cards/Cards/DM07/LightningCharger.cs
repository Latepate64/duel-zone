using Common;

namespace Cards.Cards.DM07
{
    class LightningCharger : Charger
    {
        public LightningCharger() : base("Lightning Charger", 4, Civilization.Light)
        {
            AddSpellAbilities(new OneShotEffects.ChooseOneOfYourOpponentsCreaturesInTheBattleZoneAndTapItEffect());
        }
    }
}
