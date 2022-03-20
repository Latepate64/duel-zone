using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class VirtualTripwire : Spell
    {
        public VirtualTripwire() : base("Virtual Tripwire", 3, Common.Civilization.Water)
        {
            // Choose 1 of your opponent's creatures in the battle zone and tap it.
            AddSpellAbilities(new TapChoiceEffect(1, 1, true));
        }
    }
}
