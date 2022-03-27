using Common;

namespace Cards.Cards.DM07
{
    class VenomCharger : Charger
    {
        public VenomCharger() : base("Venom Charger", 3, Civilization.Darkness)
        {
            AddSpellAbilities(new OneShotEffects.OneOfYourCreaturesGetsAbilityUntilTheEndOfTheTurnEffect(new StaticAbilities.SlayerAbility()));
        }
    }
}
