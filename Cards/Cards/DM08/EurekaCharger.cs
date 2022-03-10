using Common;

namespace Cards.Cards.DM08
{
    class EurekaCharger : Spell
    {
        public EurekaCharger() : base("Eureka Charger", 4, Civilization.Water)
        {
            AddAbilities(new Engine.Abilities.SpellAbility(new OneShotEffects.DrawEffect(1)), new StaticAbilities.ChargerAbility());
        }
    }
}
