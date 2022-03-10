using Common;

namespace Cards.Cards.DM07
{
    class EnergyCharger : Spell
    {
        public EnergyCharger() : base("Energy Charger", 3, Civilization.Fire)
        {
            AddAbilities(new Engine.Abilities.SpellAbility(new OneShotEffects.GrantPowerChoiceEffect(2000)), new StaticAbilities.ChargerAbility());
        }
    }
}
