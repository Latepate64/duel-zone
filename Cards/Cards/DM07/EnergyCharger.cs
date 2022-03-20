using Common;

namespace Cards.Cards.DM07
{
    class EnergyCharger : Charger
    {
        public EnergyCharger() : base("Energy Charger", 3, Civilization.Fire)
        {
            AddSpellAbilities(new OneShotEffects.GrantPowerChoiceEffect(2000));
        }
    }
}
