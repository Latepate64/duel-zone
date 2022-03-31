using Common;

namespace Cards.Cards.DM09
{
    class NexusCharger : Charger
    {
        public NexusCharger() : base("Nexus Charger", 6, Civilization.Light)
        {
            AddSpellAbilities(new OneShotEffects.AddCardFromYourHandToYourShieldsFaceDownEffect());
        }
    }
}
